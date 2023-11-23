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
    public DbSet<DraftContract> DraftContracts { get; set; }
    public DbSet<Contract> Contracts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<User>().Ignore(user => user.Perfil);
        //modelBuilder.Entity<frete>()
            //.HasOne(frete => frete.Destinatario) // quando possuir varios perfis
            //.whitOne(destinario => frete.Destinario) // associando o perfil ao usuario
            //.HasForeingnKey(Destinatario => destinario.DestinatarioID); // e o que eu to dizendo que é o N do relacionamento *-//
    }
}