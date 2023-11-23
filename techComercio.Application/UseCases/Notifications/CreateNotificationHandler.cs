using Twilio;
using Twilio.Rest.Api.V2010.Account;

public class CreateNotificationHandler
{
    private string AccountsID;
    private string AuthToken;
    private string TwilioPhoneNumber;

    public CreateNotificationHandler(string _accountId, string _authToken, string _twilioPhoneNumber)
    {
        AccountsID = _accountId;
        AuthToken = _authToken;
        TwilioPhoneNumber = _twilioPhoneNumber;
    }

    // criar um metodo que instancia  notificador do twilio
    public void SmsNotifier(string accountId, string authToken, string twilioPhoneNumber)
    {
        this.AccountsID = accountId;
        this.AuthToken = authToken;
        this.TwilioPhoneNumber = twilioPhoneNumber;
    }

    // criar um método para fazer o envio do sms
    public void SendSMS(string toPhoneNumber, string message)
    {
        TwilioClient.Init(AccountsID, AuthToken);
        var messageOption = new CreateMessageOptions(new Twilio.Types.PhoneNumber(toPhoneNumber))
        {
            Body = message,
            From = new Twilio.Types.PhoneNumber(TwilioPhoneNumber)
        };

        // buscando o retorno que veio da requisição do twillio
        var messageResponse = MessageResource.Create(messageOption);

        // verificar se a notificação foi enviada
        // se não enviar, criar uma log, para ser feita a retentativa

        // construir tratatmento de erros

        Console.WriteLine("Sms enviado com sucesso");

    }
    
}