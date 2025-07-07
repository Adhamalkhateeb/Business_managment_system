using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.Interface;
using BMS.BAL.Interface;
using BMS.DAL.Interface;

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
        public async Task<List<Departments>> GetAllAsync(int? page, int? rowCount, string? column = null, string? value = null) 
        {
            try
            {
                return await _departmentRepository.GetAllAsync<Departments>(page, rowCount, column, value);
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
        public async Task<Departments> GetInfoAsync(int departmentID)
        {
            Departments result;
            try
            {
                result = await _departmentRepository.GetInfoAsync<Departments>(departmentID);
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
        public async Task<Departments> GetInfoAsync(string DepartmentName)
        {
            Departments result;
            try
            {
                result = await _departmentRepository.GetInfoAsync<Departments>(DepartmentName);
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
                    return await AddNewAsync(department);
                }
                else
                {
                    return await UpdateAsync(department);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(Departments department)
        {
            return await _departmentRepository.UpdateAsync(department.ID, department.Description, department.Name, department.UpdatedByUserID);
        }

        public async Task<bool> AddNewAsync(Departments department)
        {
            var newId = await _departmentRepository.AddAsync(department.Name, department.Description, department.CreatedByUserID);
            department.ID = newId;
            return newId != -1;
        }

        /// <summary>
        /// Soft deletes a department asynchronously.
        /// </summary>
        /// <param name="id">The ID of the department to delete.</param>
        /// <param name="UserID">The ID of the user performing the deletion (optional).</param>
        /// <returns>True if the operation was successful; otherwise, false.</returns>
        public async Task<bool> DeleteAsync(int id, int? UserID)
        {
            try
            {
                return await _departmentRepository.DeleteAsync(id, UserID);
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
        public async Task<int> GetNumberOfRecordsAsync(string TableName)
        {
            try
            {
                return await _departmentRepository.GetNumberOfRecordsAsync(TableName);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}



