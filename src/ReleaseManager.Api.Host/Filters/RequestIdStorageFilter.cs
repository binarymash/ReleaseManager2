using System;
using Microsoft.AspNet.Mvc;
using ReleaseManager.Api.Host.Representations;

namespace ReleaseManager.Api.Host.Filters
{
    public class RequestIdStorageFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var requestIdStore = context.HttpContext.RequestServices.GetService(typeof (RequestIdStore)) as RequestIdStore;
            var requestId = context.HttpContext.Request.Headers["X-Request-ID"] ?? Guid.NewGuid().ToString();
            requestIdStore.Value = requestId;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
