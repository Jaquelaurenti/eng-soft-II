using MediatR;

public sealed record AcceptedDraftContractRequest (
    Guid Id,DraftContract Draft, bool  Accepted
    ) : IRequest<AcceptedDraftContractResponse>;





/*
 * public TypePolicy TypePolicy { get; set; }
    public UserPerfil UserPerfil { get; set; }
    public bool ApplyDiscount { get; set; }
    public double ValueDiscount { get; set; }
    public double ValueCashback { get; set; }
**/