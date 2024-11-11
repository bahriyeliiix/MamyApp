using Microsoft.Extensions.Logging;

namespace MamyApp.Logging.Services
{
    public class LoggingService : ILoggingService
    {
        private readonly ILogger _logger;

        public LoggingService(ILogger logger)
        {
            _logger = logger;
        }

        public void LogInformation(string message)
        {
            _logger.LogInformation(message);
        }

        public void LogWarning(string message)
        {
            _logger.LogWarning(message);
        }

        public void LogError(string message, Exception exception)
        {
            _logger.LogError(exception, message);
        }
    }
}
