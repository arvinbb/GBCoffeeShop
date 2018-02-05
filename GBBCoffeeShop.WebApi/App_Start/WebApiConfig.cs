using GBBCoffeeShop.WebApi.GeneralHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace GBBCoffeeShop.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            config.Services.Replace(typeof(IExceptionHandler), new GeneralExceptionHandler());
            config.Services.Replace(typeof(IExceptionLogger), new GeneralExceptionLogger());
        }
    }
}
