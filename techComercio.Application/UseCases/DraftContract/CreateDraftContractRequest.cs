using MediatR;

public sealed record CreateDraftContractRequest (
    User User, string Description
    ) : IRequest<CreateDraftContractResponse>;





/*
 * public TypePolicy TypePolicy { get; set; }
    public UserPerfil UserPerfil { get; set; }
    public bool ApplyDiscount { get; set; }
    public double ValueDiscount { get; set; }
    public double ValueCashback { get; set; }
**/