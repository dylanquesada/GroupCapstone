using GroupCapstone.Models;
using Newtonsoft.Json;
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
        public bool SnowComing(ApplicationUser user)
        {
            var data = GetWeather(user);
            int temp = data.daily.precipProb.Convert.ToInt32();
            int precipProb = data.daily.temperatureLow.Convert.ToInt32();
            if (precipProb >= .5 && temp <= 32)
            {
                return true;
            }
            return false;
        }
        public dynamic GetWeather(ApplicationUser user)
        {
            string url = "https://api.darksky.net/forecast/" +
                HelperClasses.APIKeys.DarkSkyKey +
                "/" +
                user.Latitude+
                "," +
                user.Longitude;
            var client = new WebClient();
            url = client.DownloadString(url);
            dynamic data = JsonConvert.DeserializeObject(url);
            return data;
        }
        public void SendNotification(ApplicationUser user)
        {
            var accountSid = HelperClasses.APIKeys.TwilioKey;
            // Your Auth Token from twilio.com/console
            var authToken = HelperClasses.APIKeys.TwilioAuthToken;

            TwilioClient.Init(accountSid, authToken);

            var smsMessage = MessageResource.Create(
                to: new PhoneNumber("+1" + user.PhoneNumber),
                from: new PhoneNumber("+12023354857"),
                body: "Snow expected, have you planned a shoveler.");
        }
    }
}