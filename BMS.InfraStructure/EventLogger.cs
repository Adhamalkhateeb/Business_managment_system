using BMS.InfraStructure.InfraStructure.interfaces;
using System;
using System.Diagnostics;

namespace BMS.InfraStructure.Logging
{
    public class EventLogLogger : ILogger
    {
        private const string Source = "BMS";
        private const string LogName = "Application";

        private readonly ILogger _fallbackLogger;

        public EventLogLogger(ILogger fallbackLogger)
        {
            _fallbackLogger = fallbackLogger;
            EnsureSourceExists();
        }

        private void EnsureSourceExists()
        {
            if (!EventLog.SourceExists(Source))
            {
                EventLog.CreateEventSource(Source, LogName);
            }
        }

        public async Task LogError(string message)
        {
            try
            {
                EventLog.WriteEntry(Source, message, EventLogEntryType.Error);
            }
            catch (Exception ex)
            {
                _fallbackLogger?.LogError($"[EventLogLogger] Failed to write to EventLog. Original error: {message}. Fallback error: {ex.Message}");
            }
        }
    }
}
