using FluentValidation;
public class DeleteUserValidator :
    AbstractValidator<DeleteUserRequest>
{
    public DeleteUserValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
