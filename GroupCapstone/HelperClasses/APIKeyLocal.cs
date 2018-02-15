using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroupCapstone.HelperClasses
{
    public static partial class APIKeys
    {
        static APIKeys()
        {
            TwilioKey = "ACa8721a074286cf791c5484bde36eb3cd";
            TwilioAuthToken = "e28b3a463791917cd1f2cbd3ce5d3d07";
            StripePublishableKey = "pk_test_ACDLYEywtcaCgGtDbVsbDAE1";
            StripeSecretKey = "sk_test_4TwlpLFfPy5phGeDdgi7NLAl";
            DarkSkyKey = "429821a10fdb44188860124451492ee1";
        }
    }
}