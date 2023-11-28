using AutoMapper;
using MediatR;
using Twilio.TwiML.Messaging;

public class CreateUserHandler :
       IRequestHandler<CreateUserRequest, CreateUserResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IRedisRepository _cache;

    public CreateUserHandler(IUnitOfWork unitOfWork,
        IUserRepository userRepository, IMapper mapper, IRedisRepository cache)
    {
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
        _mapper = mapper;
        _cache = cache;
    }

    public async Task<CreateUserResponse> Handle(CreateUserRequest request,
        CancellationToken cancellationToken)
    {
        var user = _mapper.Map<User>(request);

        _userRepository.Create(user);

        await _unitOfWork.Commit(cancellationToken);

        _cache.InsertValueRedis(user.Id.ToString(), "userPerfil", user.Perfil.ToString());

        return _mapper.Map<CreateUserResponse>(user);
    }
}
