public class UnitOfWork : IUnitOfWork
{
    // Responsabilidade: gerenciar as transações e o commit  das operações
    // no banco de dados
   
    private readonly AppDbContext _context;
    
    public UnitOfWork(AppDbContext context)
    {
        _context = context; // representação do BD
    }

    public async Task Commit(CancellationToken cancellationToken)
    {
        // esse método fará o commit, salvando todas as
        // alterações pendentes no nosso bd
        await _context.SaveChangesAsync(cancellationToken);
    }
}