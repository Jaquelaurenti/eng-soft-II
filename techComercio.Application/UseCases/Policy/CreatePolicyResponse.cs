public sealed record CreatePolicyResponse
{
    public Guid Id { get; set; }
    public TypePolicy TypePolicy { get; set; }
    public UserPerfil UserPerfil { get; set; }
    public bool ApplyDiscount { get; set; }
    public double ValueDiscount { get; set; }
    public double ValueCashback { get; set; }
}
