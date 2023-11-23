public class DraftContractRepository : BaseRepository<DraftContract>, IDraftContractRepository
{
    public DraftContractRepository(AppDbContext context) : base(context)
    {
    }
}