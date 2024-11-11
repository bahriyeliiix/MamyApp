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
            // LogSettings'i appsettings.json'dan alıyoruz
            var logSettings = configuration.GetSection("LogSettings").Get<LogSettings>();

            // Loglayıcıları DI konteynerine ekliyoruz
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()  // Konsola yazma
                .WriteTo.File(logSettings.LogFilePath, rollingInterval: RollingInterval.Day)  // Dosyaya yazma
                .CreateLogger();

            // ILogger'ı DI konteynerine ekliyoruz
            services.AddSingleton<Serilog.ILogger>(Log.Logger);

            // LoggingService'i DI konteynerine ekliyoruz
            // LoggingService'i DI konteynerine ekliyoruz
            services.AddSingleton<ILoggingService, LoggingService>();
        }
    }
}
