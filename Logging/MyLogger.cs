using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsApp.Logging
{
    public class MyLogger
    {
        private readonly ILogger _logger;

        public MyLogger(ILogger<MyLogger> logger) {
            _logger = logger;
        }

        public void LogError(string message)
        {
            _logger.LogError(message);
        }

        public void LogInfo(string message)
        {
            _logger.LogInformation(message);
        }

        public void LogDebug(string message)
        {
            _logger.LogDebug(message);
        }
    }
}
