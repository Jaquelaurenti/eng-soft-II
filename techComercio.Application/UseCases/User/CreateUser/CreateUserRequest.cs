using MediatR;

public sealed record CreateUserRequest(
        string Email, string Name, string Password, string Telephone,
            UserPerfil UserPerfil) :
            IRequest<CreateUserResponse>;