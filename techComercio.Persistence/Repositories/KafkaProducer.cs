

using Confluent.Kafka;
using System.Text.Json;

public class KafkaProducer : IKafkaProducer
{
    private readonly IProducer<string, string> _producer;

    public KafkaProducer()
    {
        // configura~]ao do servidor local do cluster do kafka
        var config = new ProducerConfig
        {
            BootstrapServers = "localhost:9092", // Endereço do servidor do kafka
        };
        // adicionando ao produtor o servidor do kafka
        _producer = new ProducerBuilder<string, string>(config).Build();
    }

    public async Task<Message> ProduceAsync(string topic, string sender, string receiver, string content)
    {

        var message = new Message
        {
            Id = Guid.NewGuid(),
            Sender = sender,
            Receiver = receiver,
            Content = content,
            Timestamp = DateTime.UtcNow,
            Status = "em processamento"
        };


        // Serializar a mensagem
        string serielizedMessage = JsonSerializer.Serialize(message);

        // chamar o método que produz a mensagem do confluente kafka
        var deliveryReport = await _producer.ProduceAsync(topic, new Message<string, string>
        {
            Value = serielizedMessage
        });

        // verificar se a mensagem foi entregue com sucesso
        if (deliveryReport.Status == PersistenceStatus.NotPersisted)
        {
            message.Status = " com erro";
            return message;
        }
        else
        {
            message.Status = " com sucesso";
            return message;
        }

    }
}