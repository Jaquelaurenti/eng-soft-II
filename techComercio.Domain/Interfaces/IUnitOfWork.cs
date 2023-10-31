public interface IUnitOfWork
{
    Task Commit(CancellationToken cancellationToken);
}

// tratando operações a transação