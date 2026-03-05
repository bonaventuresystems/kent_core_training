using DemoMVCFilters.Logger;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DemoMVCFilters.Filters
{
    public class KentResultFilter :ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
           FileLogger.CurrentLogger.Log("Result Method Executing : " + context.HttpContext.Request.Path);

            if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
            {
                (context.Result as Microsoft.AspNetCore.Mvc.ViewResult).ViewData["Master"] =
                    "~/Views/Shared/WeekEndMaster.cshtml";
            }
            else
            {
                (context.Result as Microsoft.AspNetCore.Mvc.ViewResult).ViewData["Master"] = "~/Views/Shared/WeekDayMaster.cshtml";
            }
        }
    }
}
