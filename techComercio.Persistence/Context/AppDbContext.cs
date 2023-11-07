using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    // DB Set ele é a representação de uma tabela
    // que vem do Entities do nosso Domain ao banco de dados
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Policy> Policy { get; set; }
}