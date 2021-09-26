//using Microsoft.Exchange.WebServices.Auth.Validation;
//using Microsoft.Extensions.Configuration;
//using System;
//using System.Threading.Tasks;
//using Twilio.Clients;
//using Twilio.Http;

//namespace BMW_ONBOARDING_SYSTEM.Repositories
//{
//    public class TwilioClient : ITwilioRestClient
//    {
//        string accountSid = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID");
//        string authToken = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN");

//        TwilioClient.Init(accountSid, AuthToken);

//        var message = MessageResource.Create(
//            body: "Join Earth's mightiest heroes. Like Kevin Bacon.",
//            from: new Twilio.Types.PhoneNumber("+15017122661"),
//            to: new Twilio.Types.PhoneNumber("+15558675310")
//        );

//        Console.WriteLine(message.Sid);
//    }
//}

