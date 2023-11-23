using AutoMapper;
using MediatR;

public class ConsumerMessageHandler : IRequestHandler<ConsumerMessageRequest, string>
{
    //
    private readonly IKafkaConsumer _kafkaConsumer;
    private readonly IMapper _mapper;

    public ConsumerMessageHandler(IKafkaConsumer kafkaConsumer, IMapper mapper)
    {
        _kafkaConsumer = kafkaConsumer;
        _mapper = mapper;
    }

    public async Task<string> Handle(ConsumerMessageRequest request, CancellationToken cancellationToken)
    {
        // se inscrever no tópico
        _kafkaConsumer.Subscribe(request.topic, request.group);

        // precisar consumir as mensagens
        await _kafkaConsumer.StartConsumingAsync(cancellationToken);
        return _mapper.Map<string>("Ok");

    }
}