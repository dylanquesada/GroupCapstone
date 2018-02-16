using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
namespace GroupCapstone.HelperClasses
{
    public class GoogleDistanceMatrix
    {
        public GoogleDistanceMatrix()
        {
        }
        public int GetDistance(string lat1, string lng1, string lat2, string lng2)
        {
            string url = "https://maps.googleapis.com/maps/api/distancematrix/json?units=imperial&origins=" +
            lat1 +
            "," +
            lng1 +
            "&destinations=" +
            lat2 +
            "," +
            lng2 +
            "&key=" +
            HelperClasses.APIKeys.GoogleMapsDistanceMatrixKey;

            var client = new WebClient();
            url = client.DownloadString(url);
            dynamic data = JsonConvert.DeserializeObject(url);
            int dist = data.rows[0].elements[0].distance.value;
            return dist;
        }
    }
}