using MediatR;

public sealed record CreateMessageRequest(
    string topic, string sender, string receiver, string content) : IRequest<CreateMessageResponse>;