using AutoMapper;

public class CacheMapper : Profile
{
    public CacheMapper()
    {
        CreateMap<CacheRequest, Cache>();
        CreateMap<Cache, CacheResponse>();
    }
}