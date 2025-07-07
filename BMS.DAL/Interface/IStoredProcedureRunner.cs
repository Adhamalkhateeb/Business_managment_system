using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.DAL.Interface
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
        Task<int> ExecuteNonQueryAsync(string procedureName, SqlParameter[]? parameters = null);

        /// <summary>
        /// Executes a stored procedure and retrieves all records as a list of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the records to retrieve.</typeparam>
        /// <param name="procedureName">The name of the stored procedure to execute.</param>
        /// <param name="parameters">Optional parameters for the stored procedure.</param>
        /// <returns>A task representing the asynchronous operation, with a list of records.</returns>
        Task<List<T>> GetAllBySPAsync<T>(string procedureName, SqlParameter[]? parameters = null) where T : new();

        /// <summary>
        /// Executes a stored procedure and retrieves a single record of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the record to retrieve.</typeparam>
        /// <param name="ProcedureName">The name of the stored procedure to execute.</param>
        /// <param name="parameters">Optional parameters for the stored procedure.</param>
        /// <returns>A task representing the asynchronous operation, with the single record.</returns>
        Task<T> GetSingleRecordBySPAsync<T>(string ProcedureName, SqlParameter[]? parameters = null) where T : new();

        /// <summary>
        /// Executes a stored procedure and retrieves the number of active records.
        /// </summary>
        /// <param name="procedureName">The name of the stored procedure to execute.</param>
        /// <param name="parameters">Optional parameters for the stored procedure.</param>
        /// <returns>A task representing the asynchronous operation, with the number of active records.</returns>
        Task<int> GetNumberOfActiveRecordsAsync(string procedureName, SqlParameter[]? parameters = null);
    }
}
