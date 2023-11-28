public interface IUnitOfWork
{
    Task Commit(CancellationToken cancellationToken);
}