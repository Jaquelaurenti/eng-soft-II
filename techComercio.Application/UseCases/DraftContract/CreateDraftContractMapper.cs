using AutoMapper;

public class CreateDraftContractMapper : Profile
{
    public CreateDraftContractMapper()
    {
        CreateMap<CreateDraftContractRequest, DraftContract>();
        CreateMap<DraftContract, CreateDraftContractResponse>();
    }
}