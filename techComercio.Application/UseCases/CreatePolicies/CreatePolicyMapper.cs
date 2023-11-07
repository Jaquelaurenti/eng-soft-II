using AutoMapper;

public class CreatePolicyMapper : Profile
{
    public CreatePolicyMapper()
    {
        CreateMap<CreatePolicyRequest, Polices>();
        CreateMap<Polices, CreatePolicyResponse>();
    }
}