using Twilio;
using Twilio.Rest.Api.V2010.Account;
using System;

public class CreateNotificationHandle
{
    private string accountSid;
    private string authToken;
    private string twilioPhoneNumber; // Número Twilio fornecido após registro

    public CreateNotificationHandle( string _accountSid, string _authToken, string _twilioNumber)
    {
        accountSid = _accountSid;
        authToken = _authToken;
        twilioPhoneNumber = _twilioNumber;
    }
   

    public void SmsNotifier(string accountSid, string authToken, string twilioPhoneNumber)
    {
        this.accountSid = accountSid;
        this.authToken = authToken;
        this.twilioPhoneNumber = twilioPhoneNumber;
    }


    public void SendSms(string toPhoneNumber, string message)
    {
        TwilioClient.Init(accountSid, authToken);

        var messageOptions = new CreateMessageOptions(
            new Twilio.Types.PhoneNumber(toPhoneNumber))
        {
            Body = message,
            From = new Twilio.Types.PhoneNumber(twilioPhoneNumber)
        };

        var messageResponse = MessageResource.Create(messageOptions);
        // Criar tratamento de erro

        Console.WriteLine($"SMS enviado com sucesso! SID: {messageResponse.Sid}");
    }

}



