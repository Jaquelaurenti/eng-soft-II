using AutoMapper;
using MediatR;

public class CreateDraftContractHandler : IRequestHandler<CreateDraftContractRequest, CreateDraftContractResponse>
{
    // unit of work
    private readonly IUnitOfWork _unitOfWork;
    // repository camada de dados
    private readonly IDraftContractRepository _draftRepository;
    // mapper
    private readonly IMapper _mapper;
    private readonly IKafkaProducer _kafkaRepository;


    public CreateDraftContractHandler(IUnitOfWork unitOfWork,
        IDraftContractRepository draftRepository,
        IMapper mapper, IKafkaProducer kafkaRepository)
    {
        _unitOfWork = unitOfWork;
        _draftRepository = draftRepository;
        _mapper = mapper;
        _kafkaRepository = kafkaRepository;
    }

    public async Task<CreateDraftContractResponse> Handle(CreateDraftContractRequest request, CancellationToken cancellationToken)
    {
        var draft = _mapper.Map<DraftContract>(request);

        _draftRepository.Create(draft);

        await _unitOfWork.Commit(cancellationToken);


        var notification = new CreateNotificationHandle("" +
          "ACfbf5edfc007cfd334b10ceb1a0d0db91", "2d820c66817ee777f50e0e9d29540c49", "+13602161791");

        notification.SendSms("+5511963112394", "minuta de contrato criada");

        return _mapper.Map<CreateDraftContractResponse>(draft);
    }
}