using FluentValidation;

public sealed class CreateContractValidator : AbstractValidator<CreateContractRequest>
{
    public CreateContractValidator()
    {
        RuleFor(x => x.Description).NotEmpty();    }
}

/*
 * public TypePolicy TypePolicy { get; set; }
    public UserPerfil UserPerfil { get; set; }
    public bool ApplyDiscount { get; set; }
    public double ValueDiscount { get; set; }
    public double ValueCashback { get; set; }
**/