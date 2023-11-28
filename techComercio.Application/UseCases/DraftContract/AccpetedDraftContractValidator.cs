using FluentValidation;

public sealed class AcceptedDraftContractValidator : AbstractValidator<AcceptedDraftContractRequest>
{
    public AcceptedDraftContractValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}

/*
 * public TypePolicy TypePolicy { get; set; }
    public UserPerfil UserPerfil { get; set; }
    public bool ApplyDiscount { get; set; }
    public double ValueDiscount { get; set; }
    public double ValueCashback { get; set; }
**/