using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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

        // Definindo o provedor 
        services.AddDbContext<AppDbContext>(options => options
        .UseSqlite(connectionString));

        // Adicionando escopos de instancias unica criado e compartilhado
        // no mesmo escopo http que utilizar
        // para cada transação teremos um escopo delesva
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPolicyRepository, PolicyRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IKafkaProducer, KafkaProducer>();


    }
}
