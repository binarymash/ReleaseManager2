using System.Net;
using Microsoft.AspNet.Mvc;
using ReleaseManager.Api.Host.VndError;

namespace ReleaseManager.Api.Host.Filters
{
    public class ExceptionHandlerFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var error = new Error
            {
                LogRef = context.HttpContext.Request.Headers["X-Request-ID"],
                Message = "Internal Server Error"
            };

            context.Result = new ObjectResult(error);
        }
    }
}
