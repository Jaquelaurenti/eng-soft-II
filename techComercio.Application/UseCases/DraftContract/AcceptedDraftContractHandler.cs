using AutoMapper;
using MediatR;

public class AcceptedDraftContractHandler : IRequestHandler<AcceptedDraftContractRequest, AcceptedDraftContractResponse>
{
    // unit of work
    private readonly IUnitOfWork _unitOfWork;
    // repository camada de dados
    private readonly IDraftContractRepository _draftRepository;
    // mapper
    private readonly IMapper _mapper;


    public AcceptedDraftContractHandler(IUnitOfWork unitOfWork, IDraftContractRepository draftRepository,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _draftRepository = draftRepository;
        _mapper = mapper;
    }

    public async Task<AcceptedDraftContractResponse> Handle(AcceptedDraftContractRequest request, CancellationToken cancellationToken)
    {
        var draft = await _draftRepository.Get(request.Id, cancellationToken);

        if (draft is null) return default;

        draft.Accepted = request.Accepted;
        
        _draftRepository.Update(draft);

        await _unitOfWork.Commit(cancellationToken);

        return _mapper.Map<AcceptedDraftContractResponse>(draft);
    }
}