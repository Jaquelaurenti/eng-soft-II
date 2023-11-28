using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    // Configurar como o contexto do BD se conecta a um contexto específico 
    public AppDbContext (DbContextOptions<AppDbContext> options) : base(options)
    {

    }
    // DB Set é a representação de uma tabela no BD
    public DbSet<User> Users { get; set; }
    public DbSet<Policy> Policy { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
        .Ignore(user => user.Perfil);

    }
}