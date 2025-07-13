using Dapper;
using Microsoft.Data.SqlClient;

namespace BMS.InfraStructure.InfraStructure.interfaces
{
    /// <summary>
    /// Interface for executing stored procedures in the database.
    /// </summary>
    public interface IStoredProcedureRunner
    {
        /// <summary>
        /// Executes a stored procedure that does not return any data.
        /// </summary>
        /// <param name="procedureName">The name of the stored procedure to execute.</param>
        /// <param name="parameters">Optional parameters for the stored procedure.</param>
        /// <returns>A task representing the asynchronous operation, with the number of rows affected.</returns>
        Task<int> ExecuteNonQueryAsync(string procedureName, DynamicParameters parameters = null);

        /// <summary>
        /// Executes a stored procedure and retrieves all records as a list of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the records to retrieve.</typeparam>
        /// <param name="procedureName">The name of the stored procedure to execute.</param>
        /// <param name="parameters">Optional parameters for the stored procedure.</param>
        /// <returns>A task representing the asynchronous operation, with a list of records.</returns>
        Task<List<T>> GetAllBySPAsync<T>(string procedureName,object? parameters = null) where T : new();

        /// <summary>
        /// Executes a stored procedure and retrieves a single record of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the record to retrieve.</typeparam>
        /// <param name="ProcedureName">The name of the stored procedure to execute.</param>
        /// <param name="parameters">Optional parameters for the stored procedure.</param>
        /// <returns>A task representing the asynchronous operation, with the single record.</returns>
        Task<T> GetSingleRecordBySPAsync<T>(string ProcedureName, object? parameters = null) where T : new();

        /// <summary>
        /// Executes a stored procedure and retrieves the number of active records.
        /// </summary>
        /// <param name="procedureName">The name of the stored procedure to execute.</param>
        /// <param name="parameters">Optional parameters for the stored procedure.</param>
        /// <returns>A task representing the asynchronous operation, with the number of active records.</returns>
        Task<long> GetNumberOfActiveRecordsAsync(string procedureName, object? parameters = null);
    }
}
