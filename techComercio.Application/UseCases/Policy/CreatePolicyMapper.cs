using AutoMapper;

public class CreatePolicyMapper : Profile
{
    public CreatePolicyMapper()
    {
        CreateMap<CreatePolicyRequest, Policy>();
        CreateMap<Policy, CreatePolicyResponse>();
    }
}