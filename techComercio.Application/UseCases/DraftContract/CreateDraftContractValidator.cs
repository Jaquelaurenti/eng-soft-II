using FluentValidation;

public sealed class CreateDraftContractValidator : AbstractValidator<CreateDraftContractRequest>
{
    public CreateDraftContractValidator()
    {
        RuleFor(x => x.User);
        RuleFor(x => x.Description);
    }
}

/*
 * public TypePolicy TypePolicy { get; set; }
    public UserPerfil UserPerfil { get; set; }
    public bool ApplyDiscount { get; set; }
    public double ValueDiscount { get; set; }
    public double ValueCashback { get; set; }
**/