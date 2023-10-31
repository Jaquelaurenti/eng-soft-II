using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static  class ServiceExtensions
{
   // usar para configurar a camada de persistencia no EF core
   public static void ConfigurePersistenceApp(
       this IServiceCollection services, IConfiguration configuration)
    {
        // recuperar a string de conexão da camada de presentation /api/
        var connectionString = configuration.GetConnectionString("Sqlite");

        // Definir o provedor de banco de dados
        services.AddDbContext<AppDbContext>(
            opt => opt.UseSqlite(connectionString));

        // Toda a construção de escopo da nossa aplicação ficará aqui
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUserRepository, UserRepository>();

    }
}