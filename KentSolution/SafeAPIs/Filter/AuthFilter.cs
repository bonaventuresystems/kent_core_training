using JWT.Algorithms;
using JWT.Builder;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using SafeAPIs.Controllers;

namespace SafeAPIs.Filter
{
    public class AuthFilter: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var request = context.HttpContext.Request;
            if (!request.Headers.ContainsKey("Authorization"))
            {
                context.HttpContext.Response.StatusCode = 401; // Unauthorized
                context.Result = new Microsoft.AspNetCore.Mvc.JsonResult(new { message = "Unauthorized" });
            }
            else { 
            
                request.Headers.TryGetValue("Authorization", out var token);
            var jsonPayload = JwtBuilder.Create()
                                     .WithAlgorithm(new HMACSHA256Algorithm())
                                     .WithSecret("8383838383838383838383838383838383")  // Same as encoding
                                     .Decode(token);

            var decryptedContents = JsonConvert.DeserializeObject<LoginModel>(jsonPayload);

                //you decide how to use decryptedContents here

            }
        }
    }
}
