using Microsoft.AspNetCore.Mvc.Filters;

namespace DemoMVCFilters.Filters
{
    public class KentAuth: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string userNameInSession = context.HttpContext.Session.GetString("UserName");
            if (string.IsNullOrEmpty(userNameInSession))
            {
                context.HttpContext.Response.Redirect("/Login/SignIn");
            }   
        }
    }
}
