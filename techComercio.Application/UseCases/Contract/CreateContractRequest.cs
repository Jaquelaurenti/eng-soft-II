using MediatR;

public sealed record CreateContractRequest (
    User user, string Description, DraftContract DraftContract
    ) : IRequest<CreateContractResponse>;





/*
 * public TypePolicy TypePolicy { get; set; }
    public UserPerfil UserPerfil { get; set; }
    public bool ApplyDiscount { get; set; }
    public double ValueDiscount { get; set; }
    public double ValueCashback { get; set; }
**/