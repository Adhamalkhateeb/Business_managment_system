using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.DAL.Interfaces
{
    public interface IRepository<T> where T : class, new()  
    {
        /// <summary>
        /// Asynchronously adds a new entity to the underlying data store.
        /// </summary>
        /// <param name="entity">The entity to add. Cannot be null.</param>
        /// <returns>A task that represents the asynchronous operation. The task result is <see langword="true"/> if the entity
        /// was successfully added; otherwise, <see langword="false"/>.</returns>
        Task<int> AddNewAsync(T entity);

        /// <summary>
        /// Asynchronously deletes an entity by its ID and optionally by the user ID.
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="UserID"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(int ID, int? UserID);
       
        /// <summary>
        /// Updates the specified entity in the data store asynchronously.
        /// </summary>
        /// <param name="entity">The entity to update. Cannot be <see langword="null"/>.</param>
        /// <returns><see langword="true"/> if the update operation succeeds; otherwise, <see langword="false"/>.</returns>
        Task<bool> UpdateAsync(T entity);

        /// <summary>
        /// Asynchronously retrieves a paginated list of entities from the data store.
        /// </summary>
        /// <param name="PageNumber">The page number to retrieve. If null, retrieves the first page.</param>
        /// <param name="Records">The number of records per page. If null, retrieves 10 records.</param>
        /// <param name="FilterColumn">The column to filter by. If null, no filtering is applied.</param>
        /// <param name="FilterValue">The value to filter by. If null, no filtering is applied.</param>
        /// <returns>A task that represents the asynchronous operation. The task result is a list of entities.</returns>
        Task<List<T>> GetAllAsync(int? PageNumber, int? Records, string? FilterColumn = null, string? FilterValue = null);

        /// <summary>
        /// Asynchronously retrieves the information of an entity by its ID.
        /// </summary>
        /// <param name="ID">The ID of the entity to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation. The task result is the entity information.</returns>
        Task<T> GetInfoAsync(int ID);

        /// <summary>
        /// Asynchronously retrieves the information of an entity by its title.
        /// </summary>
        /// <param name="Title">The title of the entity to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation. The task result is the entity information.</returns>
        Task<T> GetInfoAsync(string Title  );

        /// <summary>
        /// Asynchronously retrieves the number of records in a specified table.
        /// </summary>
        /// <param name="TableName">The name of the table to count records in.</param>
        /// <returns>A task that represents the asynchronous operation. The task result is the number of records.</returns>
        Task<long> GetNumberOfRecordsAsync(string TableName);
    }
}
