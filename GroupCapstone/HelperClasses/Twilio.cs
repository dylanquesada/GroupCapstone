using GroupCapstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace GroupCapstone.HelperClasses
{
    public class Twilio
    {
        // member variables
        string accountSid;
        string authToken;
        // constructor
        public Twilio()
        {
            accountSid = HelperClasses.APIKeys.TwilioKey;
            authToken = HelperClasses.APIKeys.TwilioAuthToken;
            TwilioClient.Init(accountSid, authToken);
        }
        // member methods
        public void Send(Message message)
        {
            var smsMessage = MessageResource.Create(
                to: new PhoneNumber("+1" + message.recipient),
                from: new PhoneNumber("+12023354857"),
                body: message.content);
        }
    }
}