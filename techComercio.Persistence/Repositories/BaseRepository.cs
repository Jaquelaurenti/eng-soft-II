using Microsoft.EntityFrameworkCore;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity

{
    // Implementa a interface IBaseRepository de uma entidade
    // Que irá fornecer os métodos base definidos


    // Encapsular o context do banco de dados
    protected readonly AppDbContext Context;

    public BaseRepository(AppDbContext context)
    {
        // injetando a instância do meu contexto no construtor da classe
        Context = context;
    }

    public void Create(T entity)
    {
        entity.DateCreated = DateTimeOffset.Now;
        // adiconando ao contexto
        Context.Add(entity);
    }

    public void Delete(T entity)
    {
        entity.DateDeleted = DateTimeOffset.Now;
        // adiconando ao contexto
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
        // adiconando ao contexto
        Context.Update(entity);
    }
}
