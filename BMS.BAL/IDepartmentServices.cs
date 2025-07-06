using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{


    /// <summary>  
    /// Interface for department-related services.  
    /// </summary>  
    public interface IDepartmentService
    {
        /// <summary>  
        /// Retrieves a paginated list of departments based on optional filters.  
        /// </summary>  
        /// <param name="page">The page number for pagination.</param>  
        /// <param name="rowCount">The number of rows per page.</param>  
        /// <param name="column">The column to filter by (optional).</param>  
        /// <param name="value">The value to filter by (optional).</param>  
        /// <returns>A task that represents the asynchronous operation. The task result contains a list of departments.</returns>  
        Task<List<Departments>> GetAllDepartmentsAsync(int? page, int? rowCount, string? column = null, string? value = null);

        /// <summary>  
        /// Retrieves a specific department by its ID.  
        /// </summary>  
        /// <param name="id">The ID of the department.</param>  
        /// <returns>A task that represents the asynchronous operation. The task result contains the department details.</returns>  
        Task<Departments> GetDepartmentAsync(int id);

        /// <summary>  
        /// Saves a department's details.  
        /// </summary>  
        /// <param name="dept">The department object to save.</param>  
        /// <returns>A task that represents the asynchronous operation. The task result indicates whether the save operation was successful.</returns>  
        Task<bool> SaveAsync(Departments dept);

        /// <summary>  
        /// Deletes a department by its ID.  
        /// </summary>  
        /// <param name="id">The ID of the department to delete.</param>  
        /// <param name="modifiedBy">The ID of the user who modified the record (optional).</param>  
        /// <returns>A task that represents the asynchronous operation. The task result indicates whether the delete operation was successful.</returns>  
        Task<bool> DeleteDepartmentAsync(int id, int? modifiedBy);

        /// <summary>  
        /// Retrieves the number of departments in a specified table.  
        /// </summary>  
        /// <param name="TableName">The name of the table.</param>  
        /// <returns>A task that represents the asynchronous operation. The task result contains the number of departments.</returns>  
        Task<int> GetNumberOfDepartmentsAsync(string TableName);
    }
}
