public interface IBaseRepository<T> where T : BaseEntity
{
    public void Create(T entity);
    public void Update(T entity);
    public void Delete(T entity);

    public Task<T> Get(Guid id, CancellationToken cancellationToken);
    public Task<List<T>> GetAll(CancellationToken cancellationToken);
}

// As interfaces estarão fazendo vinculação do dominio com as demais camadas
// garantindo um escopo pré definido para qualquer entidade

// ESTA TRATANDO O DADO EM SI
// OPEREAÇÕES AO DADO