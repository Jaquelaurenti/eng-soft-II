
// Classe interface genérica que servirá de base 
public interface IBaseRepository<T> where T : BaseEntity
{
    public void Create(T entity);
    public void Update(T entity);
    public void Delete(T entity);
    public Task<T> Get(Guid id, CancellationToken cancellationToken); 
    public Task<List<T>> GetAll(CancellationToken cancellationToken); // Indicando que eu posso cancelar a operação, recurso da aspnetcore

}

// Pq eu defino interface de repositorio na camada
// de dominio ?
// Pq essas interfaces que estão fazendo vinculação
// do meu dominio com as demais camadas !! 