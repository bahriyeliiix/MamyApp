using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace MamyApp.Logging.Providers
{
    public class FileLoggingProvider : ILogger
    {
        private readonly string _filePath;

        public FileLoggingProvider(string filePath)
        {
            _filePath = filePath;
        }

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

            // Log mesajını dosyaya yazma
            File.AppendAllText(_filePath, logMessage + Environment.NewLine);
        }
    }
}
