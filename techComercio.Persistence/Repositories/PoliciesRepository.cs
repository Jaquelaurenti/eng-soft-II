public class PoliciesRepository : BaseRepository<Polices>, IPoliciesRepository
{
    public PoliciesRepository(AppDbContext context) : base(context)
    {
    }
}