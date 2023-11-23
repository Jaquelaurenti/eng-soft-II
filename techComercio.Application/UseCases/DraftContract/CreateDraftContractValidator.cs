using FluentValidation;

public sealed class CreateDraftContractValidator : AbstractValidator<CreateDraftContractRequest>
{
    public CreateDraftContractValidator()
    {
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.User).NotEmpty();
    }
}