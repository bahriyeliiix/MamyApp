using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace MamyApp.API.Extensions
{
    public static class FluentValidationExtensions
    {
        public static IServiceCollection AddFluentValidationServices(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<CreateUserDtoValidator>();
            return services;
        }
    }
}
