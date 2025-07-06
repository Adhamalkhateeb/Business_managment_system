using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BAL
{
    /// <summary>
    /// Provides services for managing departments, including retrieval, creation, updating, and deletion.
    /// </summary>
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="DepartmentService"/> class with the specified repository.
        /// </summary>
        /// <param name="repo">The repository used for department operations.</param>
        public DepartmentService(IDepartmentRepository repo)
        {
            _departmentRepository = repo;
        }

        /// <summary>
        /// Retrieves a paginated list of departments asynchronously.
        /// </summary>
        /// <param name="page">The page number to retrieve.</param>
        /// <param name="rowCount">The number of rows per page.</param>
        /// <param name="column">The column to filter by (optional).</param>
        /// <param name="value">The value to filter by (optional).</param>
        /// <returns>A list of departments.</returns>
        public async Task<List<Departments>> GetAllDepartmentsAsync(int? page, int? rowCount, string? column = null, string? value = null) 
        {
            try
            {
                return await _departmentRepository.GetAllDepartmentsAsync<Departments>(page, rowCount, column, value);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Retrieves a department by its ID asynchronously.
        /// </summary>
        /// <param name="departmentID">The ID of the department.</param>
        /// <returns>The department with the specified ID.</returns>
        public async Task<Departments> GetDepartmentAsync(int departmentID)
        {
            Departments result;
            try
            {
                result = await _departmentRepository.GetDepartmentByIDAsync<Departments>(departmentID);
            }
            catch (Exception ex)
            {
                result = null;
            }
            return result;
        }

        /// <summary>
        /// Retrieves a department by its name asynchronously.
        /// </summary>
        /// <param name="DepartmentName">The name of the department.</param>
        /// <returns>The department with the specified name.</returns>
        public async Task<Departments> GetDepartment(string DepartmentName)
        {
            Departments result;
            try
            {
                result = await _departmentRepository.GetDepartmentByNameAsync<Departments>(DepartmentName);
            }
            catch (Exception ex)
            {
                result = null;
            }
            return result;
        }

        /// <summary>
        /// Saves a new department or updates an existing one asynchronously.
        /// </summary>
        /// <param name="department">The department to save or update.</param>
        /// <returns>True if the operation was successful; otherwise, false.</returns>
        public async Task<bool> SaveAsync(Departments department)
        {
            try
            {
                if (department.ID == -1)
                {
                    var newId = await _departmentRepository.AddDepartmentAsync(department.Name, department.Description, department.CreatedByUserID);
                    department.ID = newId;
                    return newId != -1;
                }
                else
                {
                    return await _departmentRepository.UpdateDepartmentAsync(department.ID, department.Description, department.Name, department.UpdatedByUserID);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Soft deletes a department asynchronously.
        /// </summary>
        /// <param name="id">The ID of the department to delete.</param>
        /// <param name="modifiedBy">The ID of the user performing the deletion (optional).</param>
        /// <returns>True if the operation was successful; otherwise, false.</returns>
        public async Task<bool> DeleteDepartmentAsync(int id, int? modifiedBy)
        {
            try
            {
                return await _departmentRepository.DeleteDepartmentAsync(id, modifiedBy);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Retrieves the total number of department records asynchronously.
        /// </summary>
        /// <param name="TableName">The name of the table containing department records.</param>
        /// <returns>The total number of department records.</returns>
        public async Task<int> GetNumberOfDepartmentsAsync(string TableName)
        {
            try
            {
                return await _departmentRepository.GetNumberOfDepartmentsRecordsAsync(TableName);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}



