using MediatR;

public sealed record CreateUserRequest(
        string Email, string Name, string Password,
            UserPerfil UserPerfil) :
            IRequest<CreateUserResponse>;