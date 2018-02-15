using Stripe;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Quartz;
namespace GroupCapstone
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            HelperClasses.JobScheduler.Start();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            StripeConfiguration.SetApiKey(ConfigurationManager.AppSettings[HelperClasses.APIKeys.StripeSecretKey]);
        }
    }
}
