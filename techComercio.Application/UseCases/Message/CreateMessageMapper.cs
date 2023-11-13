using AutoMapper;

public class CreateMessageMapper : Profile
{
    public CreateMessageMapper()
    {
        CreateMap<CreateMessageRequest, Message>();
        CreateMap<Message, CreateMessageResponse>();
    }
}