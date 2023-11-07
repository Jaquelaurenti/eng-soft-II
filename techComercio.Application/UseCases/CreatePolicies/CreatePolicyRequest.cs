using MediatR;

public sealed record CreatePolicyRequest (
    TypePolicy TypePolicy,
    UserPerfil UserPerfil,
    bool ApplyDiscount,
    double? ValueDiscount, double? ValueCashback
    ) : IRequest<CreatePolicyResponse>;





/*
 * public TypePolicy TypePolicy { get; set; }
    public UserPerfil UserPerfil { get; set; }
    public bool ApplyDiscount { get; set; }
    public double ValueDiscount { get; set; }
    public double ValueCashback { get; set; }
**/