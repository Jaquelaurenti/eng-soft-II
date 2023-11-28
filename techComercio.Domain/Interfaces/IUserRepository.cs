public interface IUserRepository :IBaseRepository<User>
{
    Task<User> GetByEmail(string email, CancellationToken cancellationToken);
}

// Interface de usuário onde eu herdo todas as operações base
// e add tudo que é específico do dominio de usuário