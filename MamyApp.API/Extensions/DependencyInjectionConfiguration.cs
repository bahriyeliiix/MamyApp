using AutoMapper;
using MamyApp.Application.Features.Users.Commands;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MamyApp.API.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection ConfigureGeneral(this IServiceCollection services)
        {
            // MediatR Configuration
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
          
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(Assembly.GetAssembly(typeof(CreateUserHandler)))
            );
            // AutoMapper Configuration
            services.AddAutoMapper(typeof(MappingProfile));

            return services;
        }
    }
}
