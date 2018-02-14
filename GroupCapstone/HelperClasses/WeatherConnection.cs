using GroupCapstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;


namespace GroupCapstone.HelperClasses
{
    public class WeatherConnection
    {
        public bool StormComing(ApplicationUser User)
        {
            var API = new 
        }
        public var GetWeather(ApplicationUser user)
        {
            string url = "https://api.darksky.net/forecast" +
                HelperClasses.APIKeys.DarkSkyKey +
                "/" +
                user.Lat +
                "," +
                user.Lng;
            var client = new WebClient();
            return client.DownloadString(url);
        }
        public void SendNotification(ApplicationUser user)
        {
            var accountSid = HelperClasses.APIKeys.TwilioKey;
            // Your Auth Token from twilio.com/console
            var authToken = HelperClasses.APIKeys.TwilioAuthToken;

            TwilioClient.Init(accountSid, authToken);

            var smsMessage = MessageResource.Create(
                to: new PhoneNumber("+1" + message.Destination),
                from: new PhoneNumber("+12023354857"),
                body: message.Body);
        }
    }
}