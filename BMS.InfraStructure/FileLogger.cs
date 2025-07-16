using BMS.InfraStructure.InfraStructure.interfaces;
using Microsoft.VisualBasic;


namespace BMS.InfraStructure.Logging
{
    public class FileLogger : ILogger
    {
        private readonly string _logFilePath;

        public FileLogger()
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string logDirectory = Path.Combine(baseDirectory, "logs");

            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }

            _logFilePath = Path.Combine(logDirectory, "errors.log");
        }

        public async Task LogError(string message)
        {
            try
            {
                string fullMessage = $"[{DateTime.Now}] {message}{Environment.NewLine}";
                await File.AppendAllTextAsync(_logFilePath, fullMessage);
            }
            catch
            {
                // Avoid recursion or crash from logging failure
            }
        }
    }
}
