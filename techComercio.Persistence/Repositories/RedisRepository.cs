using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using StackExchange.Redis;

public class RedisRepository : IRedisRepository
{
   private readonly IConfiguration configuration;

    public RedisRepository(IConfiguration _configuration)
    {
        configuration = _configuration;
    }

    public async Task<Cache> GetKeyRedis(string key)
    {
        // usado para recuperar a string de conexão no presentation
        var connectionString = configuration.GetConnectionString("Redis");
        string value = "";
        using (var connection = ConnectionMultiplexer.Connect(connectionString))
        {
            var db = connection.GetDatabase();
            // Exemplo: Recuperar o valor da chave "exemplo_chave"
            string valorRecuperado = await db.StringGetAsync(key);
            value = valorRecuperado;
        }
        string[] keys = key.Split(':');
        var cache = new Cache
        {
            Key = keys[0].Trim(),
            IdKey = new Guid(keys[1]),
            Value = value
        };

        return cache;
    }

    public void InsertValueRedis(string id, string key, string value)
    {
        // usado para recuperar a string de conexão no presentation
        var connectionString = configuration.GetConnectionString("Redis");

        using (var connection = ConnectionMultiplexer.Connect(connectionString))
        {
            var db = connection.GetDatabase();

            // Partes da chave
            string prefixo = key;
            string idKey = id;
            string chaveComposta = $"{prefixo}:{idKey}";

            // Valor a ser armazenado
            string valor = value;

            // Armazenar o valor associado à chave composta
            db.StringSet(chaveComposta, valor);

            // Exemplo: Recuperar o valor da chave "exemplo_chave"
            string valorRecuperado = db.StringGet(chaveComposta);

        }
    }
}