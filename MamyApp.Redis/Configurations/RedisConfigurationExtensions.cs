using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
public static class RedisConfigurationExtensions
{
    public static IServiceCollection AddRedisConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        var redisConfig = configuration.GetSection("RedisConfiguration").Get<RedisConfiguration>();
        services.AddSingleton(redisConfig);

        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = redisConfig.ConnectionString;
            options.InstanceName = "MamyApp_";
        });

        return services;
    }
}
