using AutoMapper;
using MediatR;

public class CacheHandler : IRequestHandler<CacheRequest, CacheResponse>
{
    // repository camada de dados
    private readonly IRedisRepository _cache;
    // mapper
    private readonly IMapper _mapper;


    public CacheHandler(IRedisRepository cache,
        IMapper mapper)
    {
        _cache = cache;
        _mapper = mapper;
    }

    public async Task<CacheResponse> Handle(CacheRequest request, CancellationToken cancellationToken)
    {
        var cache = await _cache.GetKeyRedis(request.Key);

        return _mapper.Map<CacheResponse>(cache);
    }
}