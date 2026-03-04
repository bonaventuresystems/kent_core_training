using DemoMVCFilters.Logger;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace DemoMVCFilters.Filters
{
    public class CommonExcpetionHandler : IExceptionHandler
    {
        public ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            FileLogger.CurrentLogger.Log(exception.Message);
            httpContext.Response.Redirect("/Error/Handle?message=" + exception.Message);
            return ValueTask.FromResult(true);
        }
    }
}
