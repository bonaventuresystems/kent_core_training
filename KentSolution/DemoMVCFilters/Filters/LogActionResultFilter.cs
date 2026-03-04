using DemoMVCFilters.Logger;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DemoMVCFilters.Filters
{
    public class LogActionResultFilter :ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            FileLogger.CurrentLogger.Log("Action Method Executing : " + context.HttpContext.Request.Path);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            FileLogger.CurrentLogger.Log("Action Method Executed : " + context.HttpContext.Request.Path);
        }
        public override void OnResultExecuting(ResultExecutingContext context)
        {
           FileLogger.CurrentLogger.Log("Result Method Executing : " + context.HttpContext.Request.Path);
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {
            FileLogger.CurrentLogger.Log("Result Method Executed : " + context.HttpContext.Request.Path);
        }
    }



}
