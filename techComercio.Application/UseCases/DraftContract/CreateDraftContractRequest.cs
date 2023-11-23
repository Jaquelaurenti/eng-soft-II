using MediatR;

public sealed record CreateDraftContractRequest(User User, string Description)
    : IRequest<CreateDraftContractResponse>;