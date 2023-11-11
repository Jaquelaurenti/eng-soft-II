public interface IBaseRepository<T> where T : BaseEntity
{
    public void Create(T entity); // INSERE NO BANCO DE DADOS
    public void Update(T entity); // ALTERA UM REGISTRO NO BD
    public void Delete(T entity); // DELETA O REGISTRO NO BD

    public Task<T> Get(Guid id, CancellationToken cancellationToken); // LISTA OS DADOS DA ENTIDADE COM BASE NO ID
    public Task<List<T>> GetAll(CancellationToken cancellationToken);  // LISTA A ENTIDADE POR COMPELTO
}

// As interfaces estarão fazendo vinculação do dominio com as demais camadas
// garantindo um escopo pré definido para qualquer entidade

// ESTA TRATANDO O DADO EM SI
// OPEREAÇÕES AO DADO