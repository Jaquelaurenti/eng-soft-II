public sealed record AcceptedDraftContractResponse
{
    public Guid Id { get; set; }
    public DraftContract Draft { get; set; }
    public bool Accepted { get; set; }
}
