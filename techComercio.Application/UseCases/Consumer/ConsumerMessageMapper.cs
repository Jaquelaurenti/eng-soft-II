using AutoMapper;
public class ConsumerMessageMapper : Profile
{
    public ConsumerMessageMapper()
    {
        CreateMap<string, string>();
    }
}
