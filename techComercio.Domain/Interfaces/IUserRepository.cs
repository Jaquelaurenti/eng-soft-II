public interface IUserRepository : IBaseRepository<User>
{
    Task<User> GetByEmail(string email, CancellationToken cancellationToken);
}
// Interface de usuario está herdando todas as operações base que cosntruimos no IBaseRepository