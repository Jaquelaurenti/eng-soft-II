public class BD
{
    public static void CreateDatabase(WebApplication app)
    {
        // criar um escopo com o provedor de serviço
        var serviceScope = app.Services.CreateScope();

        // obter o contexto
        var dataContext = serviceScope.ServiceProvider.GetService<AppDbContext>();

        // valida se a instância n e nula
        dataContext?.Database.EnsureCreated();

    }
}