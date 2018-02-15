using GroupCapstone.Models;
using Newtonsoft.Json;
using Quartz;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using System.Threading.Tasks;

namespace GroupCapstone.HelperClasses
{
    public class WeatherConnectionJob : IJob
    {

        public bool SnowComing(ApplicationUser user)
        {
            try
            {
                var data = GetWeather(user);
                int temp = data.daily.precipProb.Convert.ToInt32();
                int precipProb = data.daily.temperatureLow.Convert.ToInt32();
                if (precipProb >= .5 && temp <= 32)
                {
                    return true;
                }
            }
            catch(Exception e)
            {
                return false;
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
        public void SendSnowtification(ApplicationUser user)
        {

            Message message = new Message();
            message.content = "Snow expected, have you planned a shoveler.";
            message.recipient = user.PhoneNumber;
            Twilio twilio = new Twilio();
            twilio.Send(message);
        }


        public void Execute(IJobExecutionContext context)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            foreach (ApplicationUser user in db.Users)
            {
                if (SnowComing(user))
                {
                    SendSnowtification(user);
                }
            }
        }

    }
}