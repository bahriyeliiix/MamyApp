public class RedisService : IRedisService
{
    private readonly IRedisRepository _redisRepository;

    public RedisService(IRedisRepository redisRepository)
    {
        _redisRepository = redisRepository;
    }

    public async Task<T> GetDataAsync<T>(string key)
    {
        return await _redisRepository.GetAsync<T>(key);
    }

    public async Task SaveDataAsync<T>(string key, T value, TimeSpan? expiration = null)
    {
        await _redisRepository.SetAsync(key, value, expiration);
    }

    public async Task<bool> DeleteDataAsync(string key)
    {
        return await _redisRepository.RemoveAsync(key);
    }
}
