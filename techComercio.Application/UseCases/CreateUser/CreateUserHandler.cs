using AutoMapper;
using MediatR;

public class CreateUserHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
{
    // unit of work
    private readonly IUnitOfWork _unitOfWork;
    // repository camada de dados
    private readonly IUserRepository _userRepository;
    // mapper
    private readonly IMapper _mapper;


    public CreateUserHandler(IUnitOfWork unitOfWork, IUserRepository userRepository,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {
        // onde de fato vamos mandar as informações para os nossos bds
        var user = _mapper.Map<User>(request);

        _userRepository.Create(user);

        // aqui chama o nosso controle transacional
        await _unitOfWork.Commit(cancellationToken);
        return _mapper.Map<CreateUserResponse>(user);
    }
}