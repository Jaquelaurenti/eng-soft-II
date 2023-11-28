using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

// Define um método de extensão
public static class ServiceExtensions
{
    // Usado para configurar a camada de persistencia no EF Core
    public static void ConfigurePersistenceApp(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // usado para recuperar a string de conexão no presentation
        var connectionString = configuration.GetConnectionString("Sqlite");

        // Definindo o profedor 
        services.AddDbContext<AppDbContext>(options => options
        .UseSqlite(connectionString));

        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = "redis-18248.c322.us-east-1-2.ec2.cloud.redislabs.com:18248";
            options.InstanceName = "TechComercio"; // Opcional: forneça um nome de instância se necessário
        });

        // Adicionando escopos de instancias unica criado e compartilhado
        // no mesmo escopo http que utilizar
        // para cada transação teremos um escopo delesva
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IKafkaProducer, KafkaProducer>();
        services.AddScoped<IKafkaConsumer, KafkaConsumer>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IPolicyRepository, PolicyRepository>();
        services.AddScoped<IDraftContractRepository, DraftContractRepository>();
        services.AddScoped<IContractRepository, ContractRepository>();
        services.AddScoped<IRedisRepository, RedisRepository>();
    }
}
