using Serilog;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace MamyApp.Logging.Configuration
{
    public static class LoggingExtensions
    {
        public static void AddSerilogLogging(this WebApplicationBuilder builder)
        {
            // Serilog yapılandırmasını başlatın
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)
                .Enrich.FromLogContext()
                .CreateLogger();

            // Varsayılan log sağlayıcılarını kaldırın ve Serilog'u ekleyin
            builder.Logging.ClearProviders();
            builder.Logging.AddSerilog(Log.Logger);
        }
    }
}
