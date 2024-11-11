//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using StackExchange.Redis;

namespace MamyApp.API.Extensions
{
    public static class RedisExtensions
    {
        public static IServiceCollection AddRedisConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            //var redisConnectionString = configuration.GetConnectionString("RedisConnection");
            //services.AddSingleton<IConnectionMultiplexer>(sp => ConnectionMultiplexer.Connect(redisConnectionString));
            return services;
        }
    }
}
