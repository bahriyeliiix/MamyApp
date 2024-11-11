//using Microsoft.Extensions.DependencyInjection;
//using MamyApp.Core.Interfaces;
//using MamyApp.Core.Services;

namespace MamyApp.API.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServiceConfiguration(this IServiceCollection services)
        {
            //services.AddScoped<IProductService, ProductService>();
            //services.AddScoped<IUserService, UserService>();
            return services;
        }
    }
}
