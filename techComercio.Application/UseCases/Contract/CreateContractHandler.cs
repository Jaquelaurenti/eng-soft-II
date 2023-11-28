using AutoMapper;
using MediatR;

public class CreateContractHandler : IRequestHandler<CreateContractRequest, CreateContractResponse>
{
    // unit of work
    private readonly IUnitOfWork _unitOfWork;
    // repository camada de dados
    private readonly IContractRepository _contractRepository;
    // mapper
    private readonly IMapper _mapper;


    public CreateContractHandler(IUnitOfWork unitOfWork, IContractRepository contractRepository,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        contractRepository = _contractRepository;
        _mapper = mapper;
    }

    public async Task<CreateContractResponse> Handle(CreateContractRequest request, CancellationToken cancellationToken)
    {
        // Validar se a minuta de contrato foi aceita
        if(!request.DraftContract.Accepted)
        {
            return default;

        }
        // onde de fato vamos mandar as informações para os nossos bds
        var contract = _mapper.Map<Contract>(request);

        _contractRepository.Create(contract);

        // aqui chama o nosso controle transacional
        await _unitOfWork.Commit(cancellationToken);
        return _mapper.Map<CreateContractResponse>(contract);

        throw new NotImplementedException();
    }
}