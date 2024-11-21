public interface IRedisService
{
    Task<T> GetDataAsync<T>(string key);
    Task SaveDataAsync<T>(string key, T value, TimeSpan? expiration = null);
    Task<bool> DeleteDataAsync(string key);
}
