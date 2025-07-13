using Azure;
using BMS.DAL.Interfaces;
using BMS.DTOs;
using BMS.InfraStructure;
using BMS.InfraStructure.InfraStructure.interfaces;
using Dapper;
using Microsoft.Data.SqlClient;



namespace DAL
{

    /// <summary>
    /// Repository for managing Department-related database operations.
    /// </summary>
    public class DepartmentRepository : IRepository<DepartmentDTO>
    {
        private readonly IStoredProcedureRunner _sp;

        /// <summary>
        /// Initializes a new instance of the <see cref="DepartmentRepository"/> class.
        /// </summary>
        /// <param name="SP">The stored procedure runner instance.</param>
        public DepartmentRepository(IStoredProcedureRunner SP)
        {
            _sp = SP;
        }

        /// <summary>
        /// Add Department Asynchronously.
        /// </summary>
        /// <param name="department">The department entity to add.</param>
        /// <returns>New Department ID.</returns>
        public async Task<int> AddNewAsync(DepartmentDTO department)
        {
            var param = new DynamicParameters();
            param.Add("@Name", department.Name);
            param.Add("@Description", department.Description);
            param.Add("@CreatedByUserID", department.CreatedByUserID);

            return await _sp.ExecuteNonQueryAsync(SPHelper.GetName(SPDept.AddDepartment),
              param);
        }


        /// <summary>
        /// Update Department Asynchronously.
        /// </summary>
        /// <param name="department">The department entity to add.</param>
        /// <returns>True if the department was updated successfully; false otherwise.</returns>
        public async Task<bool> UpdateAsync(DepartmentDTO department)
        {
            var param = new DynamicParameters();
            param.Add("@ID", department.ID);
            param.Add("@Name", department.Name);
            param.Add("@Description", department.Description);
            param.Add("@UpdatedByUserID", department.UpdatedByUserID);
            return await _sp.ExecuteNonQueryAsync(SPHelper.GetName(SPDept.UpdateDepartment), param) != -1;
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
        public async Task<List<DepartmentDTO>> GetAllAsync(int? PageNumber, int? Records, string? FilterColumn, string? FilterValue) =>

                 await _sp.GetAllBySPAsync<DepartmentDTO>(SPHelper.GetName(SPDept.GetAllDepartments),
                new
                {
                    PageNumber = PageNumber,
                    PageSize = Records,
                    FilterColumn = FilterColumn,
                    FilterValue = FilterValue
                });


        /// <summary>
        /// Soft delete a department asynchronously.
        /// </summary>
        /// <param name="departmentID">The ID of the department to delete.</param>
        /// <param name="UserID">The ID of the user performing the deletion.</param>
        /// <returns>True if the department was deleted successfully; false otherwise.</returns>
        public async Task<bool> DeleteAsync(int departmentID, int? UserID)
        {

            var param = new DynamicParameters();
            param.Add("@ID", departmentID);


            if (await _sp.ExecuteNonQueryAsync("CheckDepartmentDependencies", param) == -1)
            {
                param.Add("@UpdatedByUserID", UserID);
                return await _sp.ExecuteNonQueryAsync(SPHelper.GetName(SPDept.DeleteDepartment), param) != -1;
            }
            else
                return false;


        }

        /// <summary>
        /// Get a department by ID asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of the record to retrieve.</typeparam>
        /// <param name="departmentID">The ID of the department to retrieve.</param>
        /// <returns>The department record.</returns>
        public async Task<DepartmentDTO> GetInfoAsync(int departmentID)  =>
                await _sp.GetSingleRecordBySPAsync<DepartmentDTO>(SPHelper.GetName(SPDept.GetDepartmentByID), new 
                        { ID = departmentID  }
                );
           
       

        /// <summary>
        /// Get a department by name asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of the record to retrieve.</typeparam>
        /// <param name="DepartmentName">The name of the department to retrieve.</param>
        /// <returns>The department record.</returns>
        public async Task<DepartmentDTO> GetInfoAsync(string DepartmentName)
        {  
                return await _sp.GetSingleRecordBySPAsync<DepartmentDTO>(SPHelper.GetName(SPDept.GetDepartmentByName), 
                    new { Name = DepartmentName }
               );
        }

        /// <summary>
        /// Get the number of department records asynchronously.
        /// </summary>
        /// <param name="TableName">The name of the table to query.</param>
        /// <returns>The number of department records.</returns>
        public async Task<long> GetNumberOfRecordsAsync(string TableName)
        {
            if (string.IsNullOrEmpty(TableName))
                throw new ArgumentException("TableName cannot be null or empty", nameof(TableName));
          
                var result = await _sp.GetNumberOfActiveRecordsAsync(SPHelper.GetName(SPDept.GetNumberOfDepartmentsRecords),new {TableName = TableName});
                return result;
           
        }
    }
}