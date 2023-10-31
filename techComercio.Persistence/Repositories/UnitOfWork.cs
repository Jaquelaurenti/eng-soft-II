
// Responsabilidade: gerenciar as transações e o commit das operações de BD
public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    public UnitOfWork(AppDbContext context)
    {
        _context = context; // representaçção de banco de dados
    }

    public async Task Commit(CancellationToken cancellationToken)
    {
        // esse método ele vai comitar e salvar as alterações no BD
        await _context.SaveChangesAsync(cancellationToken);
    }
}