public interface IRedisRepository
{
    void InsertValueRedis(string id, string key, string value);
    Task<Cache> GetKeyRedis(string key);
}