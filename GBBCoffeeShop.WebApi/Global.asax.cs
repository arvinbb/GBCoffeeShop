using GBBCoffeeShop.Common;
using Microsoft.Practices.EnterpriseLibrary.SemanticLogging;
using Microsoft.Practices.EnterpriseLibrary.SemanticLogging.Formatters;
using Microsoft.Practices.EnterpriseLibrary.SemanticLogging.Sinks;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace GBBCoffeeShop.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            UnityConfig.RegisterComponents();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Set up and enable the event listener
            string logLocation = ConfigurationManager.AppSettings["LogPath"];
            var listener = new ObservableEventListener();

            listener.EnableEvents(LoggingService.Log, EventLevel.LogAlways, Keywords.All);

            listener.LogToConsole();
            listener.LogToRollingFlatFile(logLocation, 1000, "yyyy-MM-dd", RollFileExistsBehavior.Increment, RollInterval.Week, new EventTextFormatter("===================", null));

        }
    }
}
