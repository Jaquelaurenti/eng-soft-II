public sealed record CreateDraftContractResponse
{
    public Guid Id { get; set; }
    public User User { get; set; }
    public string Description { get; set; }
    public bool Accepted { get; set; }
}
