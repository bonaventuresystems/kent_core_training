using Microsoft.AspNetCore.Mvc.Filters;

namespace DemoMVC.Filters
{
    [AttributeUsage(AttributeTargets.Class, Inherited = true)]
    public class MyActionLogCode : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //Logging related code 
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //Logging related code 
        }
    }
}
