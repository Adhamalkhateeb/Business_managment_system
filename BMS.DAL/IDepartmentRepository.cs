using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// Interface for Department Repository to manage department-related operations.
    /// </summary>
    public interface IDepartmentRepository
    {
        /// <summary>
        /// Adds a new department asynchronously.
        /// </summary>
        /// <param name="departmentName">Name of the department.</param>
        /// <param name="Description">Description of the department.</param>
        /// <param name="CreatedBy">ID of the user who created the department.</param>
        /// <returns>Returns the ID of the newly created department.</returns>
        Task<int> AddDepartmentAsync(string departmentName, string Description, int CreatedBy);

        /// <summary>
        /// Updates an existing department asynchronously.
        /// </summary>
        /// <param name="departmentID">ID of the department to update.</param>
        /// <param name="Description">Updated description of the department.</param>
        /// <param name="departmentName">Updated name of the department.</param>
        /// <param name="modifiedByUserID">ID of the user who modified the department.</param>
        /// <returns>Returns true if the update was successful, otherwise false.</returns>
        Task<bool> UpdateDepartmentAsync(int departmentID, string Description, string departmentName, int? modifiedByUserID);

        /// <summary>
        /// Retrieves all departments asynchronously with optional filtering and pagination.
        /// </summary>
        /// <typeparam name="T">Type of the result object.</typeparam>
        /// <param name="PageNumber">Page number for pagination.</param>
        /// <param name="Records">Number of records per page.</param>
        /// <param name="FilterColumn">Column to filter by.</param>
        /// <param name="FilterValue">Value to filter by.</param>
        /// <returns>Returns a list of departments.</returns>
        Task<List<T>> GetAllDepartmentsAsync<T>(int? PageNumber, int? Records, string? FilterColumn, string? FilterValue) where T : new();

        /// <summary>
        /// Deletes a department asynchronously.
        /// </summary>
        /// <param name="departmentID">ID of the department to delete.</param>
        /// <param name="UserID">ID of the user performing the deletion.</param>
        /// <returns>Returns true if the deletion was successful, otherwise false.</returns>
        Task<bool> DeleteDepartmentAsync(int departmentID, int? UserID);

        /// <summary>
        /// Retrieves a department by its ID asynchronously.
        /// </summary>
        /// <typeparam name="T">Type of the result object.</typeparam>
        /// <param name="departmentID">ID of the department to retrieve.</param>
        /// <returns>Returns the department object.</returns>
        Task<T> GetDepartmentByIDAsync<T>(int departmentID) where T : new();

        /// <summary>
        /// Retrieves a department by its name asynchronously.
        /// </summary>
        /// <typeparam name="T">Type of the result object.</typeparam>
        /// <param name="DepartmentName">Name of the department to retrieve.</param>
        /// <returns>Returns the department object.</returns>
        Task<T> GetDepartmentByNameAsync<T>(string DepartmentName) where T : new();

        /// <summary>
        /// Retrieves the number of department records asynchronously.
        /// </summary>
        /// <param name="TableName">Name of the table to count records from.</param>
        /// <returns>Returns the number of department records.</returns>
        Task<int> GetNumberOfDepartmentsRecordsAsync(string TableName);
    }
}
