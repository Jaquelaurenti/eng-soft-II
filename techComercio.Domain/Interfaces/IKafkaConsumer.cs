public interface IKafkaConsumer
{
    event EventHandler<MessageReceivedEventArgs> OnMessageReceived;
    void Subscribe(string topic, string group);
    void StopConsuming();
    Task StartConsumingAsync(CancellationToken cancellationToken);
}

// Subscribe - Método para se inscrever no tópico e sempre que cair mensagens eu estou pronto para consumir
// StartConsuming - Quando eu inicio o processo de consumo das mensagens no tópico
// StopConsuming - Garante a finalização de todos os consumos das mensagens disponíveis
// OnMessageReceived - Permite que os consumidores se inscrevam para receber notificações sempre que uma mensagem é recebida/postada