using AutoMapper;

public sealed class GetAllUserMapper : Profile
{
    public GetAllUserMapper()
    {
        CreateMap<User, GetAllUserResponse>();
    }
}
