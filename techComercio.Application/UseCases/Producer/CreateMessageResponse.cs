
public sealed record CreateMessageResponse
{
    public Guid MessageId { get; set; }
    public string Sender { get; set; }
    public string Receiver { get; set; }
    public string Content { get; set; }
    public DateTime Timestamp { get; set; }
    public string Status { get; set; }

}
