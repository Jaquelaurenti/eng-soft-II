using AutoMapper;

public class ConsumerMessageMapper : Profile
{
    public ConsumerMessageMapper()
    {
        CreateMap<ConsumerMessageRequest, MessageReceivedEventArgs>();
    }
}