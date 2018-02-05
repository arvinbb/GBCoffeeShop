using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace GBBCoffeeShop.WebApi.GeneralHandlers
{
    public class GeneralExceptionHandler : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            var result = new GeneralErrorResult(context.Exception);
            result.Request = context.ExceptionContext.Request;

            context.Result = result;
        }


        private class GeneralErrorResult : IHttpActionResult
        {
            public HttpRequestMessage Request { get; set; }
            public string Content { get; set; }


            private HttpStatusCode statusCode = HttpStatusCode.InternalServerError;

            public GeneralErrorResult(Exception ex)
            {
                Content = "Error occured in the server";                
            }

            public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
            {
                HttpResponseMessage response =
                    new HttpResponseMessage(statusCode);

                var json = Newtonsoft.Json.JsonConvert.SerializeObject(new { message = Content });
                response.Content = new StringContent(json);
                response.RequestMessage = Request;
                response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                return Task.FromResult(response);
            }
        }
    }
}