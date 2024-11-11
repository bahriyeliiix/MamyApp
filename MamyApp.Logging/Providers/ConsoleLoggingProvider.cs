using Microsoft.Extensions.Logging;
using System;

namespace MamyApp.Logging.Providers
{
    public class ConsoleLoggingProvider : ILogger
    {
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel >= LogLevel.Information;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel)) return;

            var logMessage = $"{DateTime.UtcNow} [{logLevel}] {formatter(state, exception)}";
            Console.WriteLine(logMessage);
        }
    }
}
