using Microsoft.EntityFrameworkCore;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
        // garante que o contexto de BD esteja disponivel para userRepository
    }

    public async Task<User> GetByEmail(string email, CancellationToken cancellationToken)
    {
        return await Context.Users.FirstOrDefaultAsync(
            x => x.Email.Equals(email), cancellationToken);
    }
}