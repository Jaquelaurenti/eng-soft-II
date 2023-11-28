using FluentValidation;


public sealed class CacheValidator : AbstractValidator<CacheRequest>
{
    public CacheValidator()
    {
        RuleFor(x => x.Key).NotEmpty();
    }
}
