using AutoMapper;
using MediatR;


public class CreateMessageHandler :
       IRequestHandler<CreateMessageRequest, CreateMessageResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IKafkaProducer _kafkaRepository;
    private readonly IMapper _mapper;

    public CreateMessageHandler(IUnitOfWork unitOfWork,
        IKafkaProducer kafkaRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _kafkaRepository = kafkaRepository;
        _mapper = mapper;
    }

    public async Task<CreateMessageResponse> Handle(CreateMessageRequest request,
        CancellationToken cancellationToken)
    {
        var message = await _kafkaRepository.ProduceAsync(
            request.topic,
            request.sender,
            request.receiver,
            request.content
            );

        var notification = new CreateNotificationHandle("" +
          "ACfbf5edfc007cfd334b10ceb1a0d0db91", "2d820c66817ee777f50e0e9d29540c49", "+13602161791");

        notification.SendSms("+5511963112394", "contrato criado");

        return _mapper.Map<CreateMessageResponse>(message);

    }
}
