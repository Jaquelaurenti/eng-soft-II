using AutoMapper;
using MediatR;


public class CreateDraftContractHandle : IRequestHandler<CreateDraftContractRequest, CreateDraftContractResponse>
{
    // unit of work para garantir que foi comitado no BD
    private readonly IUnitOfWork _unitOfWork;

    // camada de repositorio
    private readonly IDraftContractRepository _repository;


    // mapper
    private readonly IMapper _mapper;
    public CreateDraftContractHandle(IUnitOfWork unitOfWork, IDraftContractRepository draftContract, IMapper mapper )
    {
        _mapper = mapper;
        _repository = draftContract;
        _unitOfWork = unitOfWork;

    }

    public async Task<CreateDraftContractResponse> Handle(CreateDraftContractRequest request, CancellationToken cancellationToken)
    {
        // validar se o usuario que esta sendo inserido no contrato existe no banco
        // chamar o repositorio de usuario passando u rquest.User.id como parametro no getbYId


        // criar e garantir que a minuta de contrato foi persistida no banco

        var draft = _mapper.Map<DraftContract>(request);
        _repository.Create(draft);

        // comita a transação
        await _unitOfWork.Commit(cancellationToken);

        // notificar o usuário que a minuta está disponível

        var notificaton = new CreateNotificationHandler("AC812e2053194efbd357fabba62ddeab26",
            "44794ec3ab3ac10a6748a9915837ba28", "+19018815212");

        // adicionar uma estratégia no cadastro do usuario, para quando salvar no banco, sempre add o +55
        notificaton.SendSMS("+5519982220048", "Olá, temos uma minuta de contrato disponível para assinatura");


        return _mapper.Map<CreateDraftContractResponse>(draft);

    }
}