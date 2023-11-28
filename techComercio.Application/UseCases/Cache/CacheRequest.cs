using MediatR;

public sealed record CacheRequest(string Key) : IRequest<CacheResponse>;





