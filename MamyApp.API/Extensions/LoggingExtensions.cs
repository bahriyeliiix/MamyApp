using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace MamyApp.API.Extensions
{
    public static class LoggingExtensions
    {
        public static IServiceCollection AddLoggingConfiguration(this IServiceCollection services)
        {
            services.AddLogging(logging =>
            {
                logging.ClearProviders();
                logging.AddConsole();
                logging.AddDebug();
                // Diğer logging sağlayıcıları buraya ekleyebilirsiniz
            });
            return services;
        }
    }
}
