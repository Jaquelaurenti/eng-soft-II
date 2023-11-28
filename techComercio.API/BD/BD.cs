
public class BD
{
    
    public static void CreateDatabase(WebApplication app)
    {
        // criando um escopo do provedor de serviço
        var serviceScope = app.Services.CreateScope();
        // obtendo o contexto
        var dataContext = serviceScope.ServiceProvider.GetService<AppDbContext>();
        // validando se a instância do serviço não é nula
        dataContext?.Database.EnsureCreated();
        // caso o banco não exista ele cria o modelo de dados do BD com base
        // no que foi definido nas entidades da camada de domínio
        // no ambiente de produção é recomendado aplicar as migrations
    }

}

