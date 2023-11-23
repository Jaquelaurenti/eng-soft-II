using MediatR;

public sealed record CreateUserRequest(
        string Email, string Name, string Password,
            UserPerfil UserPerfil, string Telephone) :
            IRequest<CreateUserResponse>;