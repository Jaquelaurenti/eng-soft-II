using Microsoft.EntityFrameworkCore;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    // Implementar  a interface IBaseRepository que fornecerá os métodos base definidos na interface

    // Encapsular contexto de banco de dados

    protected readonly AppDbContext Context;

    public BaseRepository(AppDbContext context)
    {
        // injetar a instancia do contexto ao construtor
        Context = context;
    }

    public void Create(T entity)
    {
        entity.DateCreated = DateTimeOffset.Now;
        Context.Add(entity);
    }

    public void Delete(T entity)
    {
        entity.DateDeleted = DateTimeOffset.Now;
        Context.Remove(entity);
    }

    public async Task<T> Get(Guid id, CancellationToken cancellationToken)
    {
        return await Context.Set<T>().FirstOrDefaultAsync(
            x => x.Id.Equals(id), cancellationToken);
    }

    public async Task<List<T>> GetAll(CancellationToken cancellationToken)
    {
        return await Context.Set<T>().ToListAsync(cancellationToken);
    }

    public void Update(T entity)
    {
        entity.DateUpdated = DateTimeOffset.Now;
        Context.Update(entity);
    }
}