using System;
using System.Data;
using Microsoft.Data.SqlClient;
using BMS.InfraStructure.InfraStructure.interfaces;


namespace BMS.InfraStructure.Logging
{
    public class DbLogger : ILogger
    {
        private readonly IStoredProcedureRunner _runner;
        private readonly ILogger _fallbackLogger;

        public DbLogger(IStoredProcedureRunner runner, ILogger fallbackLogger)
        {
            _runner = runner;
            _fallbackLogger = fallbackLogger;
        }

        public async void LogError(string message)
        {
            try
            {
                var parameters = new[]
                {
                    new SqlParameter("@Message", SqlDbType.NVarChar) { Value = message },
                    new SqlParameter("@LoggedAt", SqlDbType.DateTime) { Value = DateTime.Now },
                    new SqlParameter("@Severity", SqlDbType.NVarChar) { Value = "Error" }
                };

                await _runner.ExecuteNonQueryAsync(SPHelper.GetName(SPLogger.LogError), parameters);
            }
            catch (Exception ex)
            {
                _fallbackLogger?.LogError($"[DbLogger] Failed to write to DB. Original error: {message}. Fallback error: {ex.Message}");
            }
        }
    }
}
