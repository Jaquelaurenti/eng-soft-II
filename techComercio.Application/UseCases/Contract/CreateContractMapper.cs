using AutoMapper;

public class CreateContractMapper : Profile
{
    public CreateContractMapper()
    {
        CreateMap<CreateMessageRequest, Contract>();
        CreateMap<Contract, CreateMessageResponse>();
    }
}