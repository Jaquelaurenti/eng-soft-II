using AutoMapper;

public class AcceptedDraftContractMapper : Profile
{
    public AcceptedDraftContractMapper()
    {
        CreateMap<AcceptedDraftContractRequest, DraftContract>();
        CreateMap<DraftContract, AcceptedDraftContractResponse>();
    }
}