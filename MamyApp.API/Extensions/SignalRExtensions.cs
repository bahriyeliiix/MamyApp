using Microsoft.Extensions.DependencyInjection;

namespace MamyApp.API.Extensions
{
    public static class SignalRExtensions
    {
        public static IServiceCollection AddSignalRConfiguration(this IServiceCollection services)
        {
            services.AddSignalR();
            return services;
        }
    }
}
