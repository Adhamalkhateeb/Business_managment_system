using System;
using System.Diagnostics;
using System.IO;
using System.Security;

namespace Utilities
{
    public static class Logger
    {
        private static readonly string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs", "errors.log");
        private const string source = "BMS";
        private const string logName = "Application";

        /// <summary>
        /// Logs an error to Event Viewer and falls back to a file if it fails.
        /// Optionally logs to database.
        /// </summary>
        public static void LogError(string message, bool logToDB = false)
        {
            try
            {
                EnsureEventSourceExists();
                EventLog.WriteEntry(source, message, EventLogEntryType.Error);
            }
            catch (Exception ex)
            {
                WriteToFallbackFile($"[LOG ERROR] {message}\n[EVENTLOG FAILURE] {ex.Message}\n[Date/Time]: {DateTime.Now}");
            }

            if (logToDB)
            {
                // Future: Insert into Logs table using ADO.NET
            }
        }


        /// <summary>
        /// Checks if the event source exists and creates it if necessary.
        /// </summary>
        private static void EnsureEventSourceExists()
        {
            if (!EventLog.SourceExists(source))
            {
                try
                {
                    EventLog.CreateEventSource(source, logName);
                }
                catch (Exception ex)
                {
                    WriteToFallbackFile($"[EVENT SOURCE CREATION FAILED] {ex.Message}\n[Date/Time]: {DateTime.Now}");
                    throw; // Let LogError() handle fallback
                }
            }
        }

        /// <summary>
        /// Writes log messages to a file as a fallback.
        /// </summary>
        private static void WriteToFallbackFile(string content)
        {
            try
            {
                string directory = Path.GetDirectoryName(logFilePath);
                if (!Directory.Exists(directory))
                    Directory.CreateDirectory(directory);

                File.AppendAllText(logFilePath, $"[{DateTime.Now}] {content}\n");
            }
            catch
            {
                // Silent fail — avoid infinite recursion
            }
        }
    }
}
