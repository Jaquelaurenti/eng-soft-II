using MediatR;

public sealed record DeleteUserRequest(Guid Id)
                  : IRequest<DeleteUserResponse>;
