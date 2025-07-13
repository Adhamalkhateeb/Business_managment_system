using System;
using System.Data;
using Microsoft.Data.SqlClient;
using BMS.InfraStructure.InfraStructure.interfaces;
using Dapper;


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

                var param = new DynamicParameters();
                param.Add("@Message", message);
                param.Add("@LoggedAt", DateTime.Now);
                param.Add("@Severity", "Error");
               

                await _runner.ExecuteNonQueryAsync(SPHelper.GetName(SPLogger.LogError), param);
            }
            catch (Exception ex)
            {
                _fallbackLogger?.LogError($"[DbLogger] Failed to write to DB. Original error: {message}. Fallback error: {ex.Message}");
            }
        }
    }
}
