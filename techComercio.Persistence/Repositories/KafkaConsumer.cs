using Confluent.Kafka;
using static Confluent.Kafka.ConfigPropertyNames;

public class KafkaConsumer : IKafkaConsumer
{
    private bool isConsuming = false;

    public event EventHandler<MessageReceivedEventArgs> OnMessageReceived;
    private IConsumer<Ignore, string> consumer;

    public void Subscribe(string topic, string group)
    {
        var consumerConfig = new ConsumerConfig
        {
            BootstrapServers = "localhost:9092", // Endereço do seu servidor Kafka
            GroupId = group, // Identificador de grupo para o consumidor
            AutoOffsetReset = AutoOffsetReset.Earliest, // Define onde começar a consumir mensagens se o offset inicial não estiver disponível
            EnableAutoCommit = false
        };

        consumer = new ConsumerBuilder<Ignore, string>(consumerConfig).Build();

        consumer.Subscribe(topic);
    }

    public async Task StartConsumingAsync(CancellationToken cancellationToken)
    {
        isConsuming = true;

        while (isConsuming)
        {
            try
            {
                var consumeResult = await Task.Run(() => consumer.Consume(cancellationToken), cancellationToken);

                if (consumeResult != null && consumeResult.Message != null)
                {
                    string message = consumeResult.Message.Value;
                    OnMessageReceived?.Invoke(this, new MessageReceivedEventArgs { Message = message });
                }
                StopConsuming();
            }
            catch
            {

            }
            
        }
    }

    public void StopConsuming()
    {
        isConsuming = false;
        consumer.Close();
    }
}