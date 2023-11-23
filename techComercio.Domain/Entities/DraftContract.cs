public class DraftContract : BaseEntity
{
    public User User { get; set; }
    public string Description { get; set; }
    public bool Accepted { get; set; }
}