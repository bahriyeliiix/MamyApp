
namespace MamyApp.API.Extensions
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection AddRepositoryConfiguration(this IServiceCollection services)
        {
            //services.AddScoped<IProductRepository, ProductRepository>();
            //services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
