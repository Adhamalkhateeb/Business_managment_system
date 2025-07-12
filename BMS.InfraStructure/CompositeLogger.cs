using BMS.InfraStructure.InfraStructure.interfaces;
using System.Collections.Generic;

namespace BMS.InfraStructure.Logging
{
    public class CompositeLogger : ILogger
    {
        private readonly IEnumerable<ILogger> _loggers;

        public CompositeLogger(IEnumerable<ILogger> loggers)
        {
            _loggers = loggers;
        }

        public void LogError(string message)
        {
            foreach (var logger in _loggers)
            {
                try
                {
                    logger.LogError(message);
                }
                catch
                {
                    // Don't let one logger crash the others
                }
            }
        }
    }
}
