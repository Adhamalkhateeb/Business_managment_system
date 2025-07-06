using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IStoredProcedureRunner
    {
        Task<int> ExecuteNonQueryAsync(string procedureName, SqlParameter[]? parameters = null);
        Task<List<T>> GetAllBySPAsync <T>(string procedureName, SqlParameter[]? parameters = null) where T : new();
        Task<T> GetSingleRecordBySPAsync<T>(string ProcedureName, SqlParameter[]? parameters = null)where T : new();
        Task<int> GetNumberOfActiveRecordsAsync(string procedureName, SqlParameter[]? parameters = null);
    }
}
