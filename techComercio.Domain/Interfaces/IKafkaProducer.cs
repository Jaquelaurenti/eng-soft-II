public interface IKafkaProducer 
{
    Task<Message> ProduceAsync(
        string topic, string sender, string receiver, string content);
}