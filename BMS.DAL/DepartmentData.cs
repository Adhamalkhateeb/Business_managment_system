
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using Utilities;



namespace DAL
{

    /// <summary>
    /// Repository for managing Department-related database operations.
    /// </summary>
    public class DepartmentRepositiry : IDepartmentRepository
    {
        private readonly IStoredProcedureRunner _db;

        /// <summary>
        /// Initializes a new instance of the <see cref="DepartmentRepositiry"/> class.
        /// </summary>
        /// <param name="db">The stored procedure runner instance.</param>
        public DepartmentRepositiry(IStoredProcedureRunner db)
        {
            _db = db;
        }

        /// <summary>
        /// Add Department Asynchronously.
        /// </summary>
        /// <param name="departmentName">The name of the department.</param>
        /// <param name="Description">The description of the department.</param>
        /// <param name="CreatedBy">The ID of the user who created the department.</param>
        /// <returns>New Department ID.</returns>
        public async Task<int> AddDepartmentAsync(string departmentName, string Description, int CreatedBy)
        {
            try
            {
                return await _db.ExecuteNonQueryAsync(SPHelper.GetName(SPDept.AddDepartment), new SqlParameter[]
                {
                        new SqlParameter("@Name", departmentName),
                        new SqlParameter("@Description", Description),
                        new SqlParameter("@CreatedByUserID", CreatedBy)
                });
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Update Department Asynchronously.
        /// </summary>
        /// <param name="departmentID">The ID of the department to update.</param>
        /// <param name="Description">The updated description of the department.</param>
        /// <param name="departmentName">The updated name of the department.</param>
        /// <param name="modifiedByUserID">The ID of the user who modified the department.</param>
        /// <returns>True if the department was updated successfully; false otherwise.</returns>
        public async Task<bool> UpdateDepartmentAsync(int departmentID, string Description, string departmentName, int? modifiedByUserID)
        {
            try
            {
                return await _db.ExecuteNonQueryAsync(SPHelper.GetName(SPDept.UpdateDepartment), new SqlParameter[]
                {
                        new SqlParameter("@Name", departmentName),
                        new SqlParameter("@ID", departmentID),
                        new SqlParameter("@Description", Description),
                        new SqlParameter("@UpdatedByUserID", modifiedByUserID)
                }) != -1;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Get all department records asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of the records to retrieve.</typeparam>
        /// <param name="PageNumber">The page number for pagination.</param>
        /// <param name="Records">The number of records per page.</param>
        /// <param name="FilterColumn">The column to filter by.</param>
        /// <param name="FilterValue">The value to filter by.</param>
        /// <returns>A list of department records.</returns>
        public async Task<List<T>> GetAllDepartmentsAsync<T>(int? PageNumber, int? Records, string? FilterColumn, string? FilterValue) where T : new()
        {
            try
            {
                return await _db.GetAllBySPAsync<T>(SPHelper.GetName(SPDept.GetAllDepartments), new SqlParameter[]
                {
                        new SqlParameter("@PageNumber", PageNumber ?? 1),
                        new SqlParameter("@PageSize", Records ?? 8),
                        new SqlParameter("@FilterColumn", FilterColumn),
                        new SqlParameter("@FilterValue", FilterValue)
                });
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Soft delete a department asynchronously.
        /// </summary>
        /// <param name="departmentID">The ID of the department to delete.</param>
        /// <param name="UserID">The ID of the user performing the deletion.</param>
        /// <returns>True if the department was deleted successfully; false otherwise.</returns>
        public async Task<bool> DeleteDepartmentAsync(int departmentID, int? UserID)
        {
            try
            {
                if (await _db.ExecuteNonQueryAsync("CheckDepartmentDependencies", new SqlParameter[] { new SqlParameter("@DepartmentID", departmentID) }) != 1)
                    return await _db.ExecuteNonQueryAsync(SPHelper.GetName(SPDept.DeleteDepartment), new SqlParameter[]
                    {
                            new SqlParameter("@ID", departmentID),
                            new SqlParameter("@UpdatedByUserID", UserID)
                    }) != -1;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the department.", ex);
            }
        }

        /// <summary>
        /// Get a department by ID asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of the record to retrieve.</typeparam>
        /// <param name="departmentID">The ID of the department to retrieve.</param>
        /// <returns>The department record.</returns>
        public async Task<T> GetDepartmentByIDAsync<T>(int departmentID) where T : new()
        {
            try
            {
                return await _db.GetSingleRecordBySPAsync<T>(SPHelper.GetName(SPDept.GetDepartmentByID), new SqlParameter[]
                {
                        new SqlParameter("@ID", departmentID)
                });
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Get a department by name asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of the record to retrieve.</typeparam>
        /// <param name="DepartmentName">The name of the department to retrieve.</param>
        /// <returns>The department record.</returns>
        public async Task<T> GetDepartmentByNameAsync<T>(string DepartmentName) where T : new()
        {
            try
            {
                return await _db.GetSingleRecordBySPAsync<T>(SPHelper.GetName(SPDept.GetDepartmentByName), new SqlParameter[]
                {
                        new SqlParameter("@Name", DepartmentName)
                });
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Get the number of department records asynchronously.
        /// </summary>
        /// <param name="TableName">The name of the table to query.</param>
        /// <returns>The number of department records.</returns>
        public async Task<int> GetNumberOfDepartmentsRecordsAsync(string TableName)
        {
            if (string.IsNullOrEmpty(TableName))
                throw new ArgumentException("TableName cannot be null or empty", nameof(TableName));
            try
            {
                var result = await _db.GetNumberOfActiveRecordsAsync(SPHelper.GetName(SPDept.GetNumberOfDepartmentsRecords), new SqlParameter[]
                {
                        new SqlParameter("@TableName", TableName),
                });
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving the number of records.", ex);
            }
        }
    }
}