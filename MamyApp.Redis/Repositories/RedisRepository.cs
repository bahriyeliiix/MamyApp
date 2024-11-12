using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

public interface IRedisRepository
{
    Task<T> GetAsync<T>(string key);
    Task SetAsync<T>(string key, T value, TimeSpan? expiration = null);
    Task<bool> RemoveAsync(string key);
}

public class RedisRepository : IRedisRepository
{
    private readonly IDistributedCache _cache;

    public RedisRepository(IDistributedCache cache)
    {
        _cache = cache;
    }

    public async Task<T> GetAsync<T>(string key)
    {
        var value = await _cache.GetStringAsync(key);
        return value == null ? default : JsonSerializer.Deserialize<T>(value);
    }

    public async Task SetAsync<T>(string key, T value, TimeSpan? expiration = null)
    {
        var options = new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = expiration };
        var json = JsonSerializer.Serialize(value);
        await _cache.SetStringAsync(key, json, options);
    }

    public async Task<bool> RemoveAsync(string key)
    {
        await _cache.RemoveAsync(key);
        return true;
    }
}
