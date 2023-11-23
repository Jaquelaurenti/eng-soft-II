using MediatR;

public sealed record ConsumerMessageRequest(string topic, string group) : IRequest<string>;