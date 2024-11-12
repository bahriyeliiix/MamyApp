using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MamyApp.Logging.Providers;
using MamyApp.Logging.Services;
using Serilog;

namespace MamyApp.Logging.Configuration
{
    public static class LoggingConfiguration
    {
        public static void ConfigureLogging(this IServiceCollection services, IConfiguration configuration)
        {
            var logSettings = configuration.GetSection("LogSettings").Get<LogSettings>();

            // Get the user's Documents folder path
            var logDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MyAppLogs");

            // Ensure the log directory exists
            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
                Console.WriteLine("Log directory created at: " + logDirectory);
            }

            // Ensure the log file path is valid
            var logFilePath = Path.Combine(logDirectory, "log-.txt");

            // Print log file path for debugging
            Console.WriteLine($"Log File Path: {logFilePath}");

            // Configure Serilog to write to a file with rolling interval
            try
            {
                Log.Logger = new LoggerConfiguration()
                    .WriteTo.File(logFilePath, rollingInterval: RollingInterval.Day, retainedFileCountLimit: 7) // Retain only the last 7 days of logs
                    .CreateLogger();
                services.AddSingleton<ILogger>(Log.Logger);
                services.AddSingleton<ILoggingService, LoggingService>();

                Console.WriteLine("Logger initialized successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error initializing logger: " + ex.Message);
            }
        }


    }
}
