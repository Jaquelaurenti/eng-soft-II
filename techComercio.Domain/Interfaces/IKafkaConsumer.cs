public interface IKafkaConsumer
{
    event EventHandler<MessageReceivedEventArgs> OnMessageReceived;
    void Subscribe(string topic, string group);
    Task StartConsumingAsync(CancellationToken cancellationToken);
    void StopConsuming();
}

/*
 Subscribe: Este método é usado para se inscrever em um tópico específico do Kafka
para começar a consumir mensagens desse tópico.

StartConsuming: Este método inicia o processo de consumo de mensagens do Kafka
após a inscrição em um ou mais tópicos. A lógica de consumo deve ser implementada
na classe concreta que implementa a interface.

StopConsuming: Esse método permite parar o processo de consumo de mensagens, se
necessário.

OnMessageReceived: Este é um evento que permite que os consumidores se inscrevam
para receber notificações quando uma nova mensagem é recebida. Ele fornece
informações sobre a mensagem recebida, como o conteúdo da mensagem, que pode
ser repassado aos ouvintes registrados.
 
 */