using MediatR;

public sealed record GetAllUserRequest : 
                   IRequest<List<GetAllUserResponse>>;
