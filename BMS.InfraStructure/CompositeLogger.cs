using BMS.InfraStructure.InfraStructure.interfaces;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace BMS.InfraStructure.Logging
{
    public class CompositeLogger : ILogger
    {
        private readonly IEnumerable<ILogger> _loggers;

        public CompositeLogger(IEnumerable<ILogger> loggers)
        {
            _loggers = loggers;
        }

        public async Task  LogError(string message)
        {
            var tasks = _loggers.Select(logger =>
            Task.Run(() => logger.LogError(message)));
            await Task.WhenAll(tasks);
        }
    }
}
