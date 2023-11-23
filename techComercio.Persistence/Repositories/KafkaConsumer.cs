using Confluent.Kafka;

public class KafkaConsumer : IKafkaConsumer
{
    private bool isConsuming = false;

    public event EventHandler<MessageReceivedEventArgs> OnMessageReceived;

    private IConsumer<Ignore, string> consumer;


    // Consumo das mensagens
    public async Task StartConsumingAsync(CancellationToken cancellationToken)
    {
        isConsuming = true;
        while(isConsuming)
        {
            try
            {
                var consumeResult = await Task.Run(() => consumer.Consume(cancellationToken), cancellationToken);
                if(consumeResult != null && consumeResult.Message != null)
                {
                    // inscrição de notificação do consumo da mensagem
                    string message = consumeResult.Message.Value;
                    OnMessageReceived?.Invoke(this, new MessageReceivedEventArgs { Message = message });
                }
                // depois de estar inscrito eu fecho o consumidor
                StopConsuming();

            }
            catch(Exception ex)
            {
                // construir exceção
            }
        }
    }

    // fechando a conexão com o consumidor
    public void StopConsuming()
    {
        isConsuming = false;
        consumer.Close();
    }


    // Inscrição do tópico
    public void Subscribe(string topic, string group)
    {

        // try catch no caso de não conseguir se inscrever no tópico

        // configurar a string de conexão com o Kafka
        // configura~]ao do servidor local do cluster do kafka
        var config = new ConsumerConfig
        {
            BootstrapServers = "localhost:9092", // Endereço do servidor do kafka
            GroupId = group, // identificador do grupa para consumo do tópico
            AutoOffsetReset = AutoOffsetReset.Earliest, // a partir da primeira ou da ultima
            EnableAutoCommit = false
        };

        // criando o consumidor e deixando disponível 
        consumer = new ConsumerBuilder<Ignore, string>(config).Build();

        consumer.Subscribe(topic);
    }
}