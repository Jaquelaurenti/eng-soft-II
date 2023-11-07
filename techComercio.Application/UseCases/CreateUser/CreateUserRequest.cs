using MediatR;

public sealed record CreateUserRequest (
    string Email,
    string Name,
    string Password,
    UserPerfil Perfil
    ) : IRequest<CreateUserResponse>;
 