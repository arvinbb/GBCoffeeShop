using GBBCoffeeShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ExceptionHandling;

namespace GBBCoffeeShop.WebApi.GeneralHandlers
{
    public class GeneralExceptionLogger : ExceptionLogger
    {
        public override void Log(ExceptionLoggerContext context)
        {
            LoggingService.Log.Exception(context.Exception.Message, context.Exception);
        }
    }
}