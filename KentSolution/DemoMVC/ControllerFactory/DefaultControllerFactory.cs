
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace DemoMVC.ControllerFactory
{
    public class DefaultControllerFactory : IControllerFactory
    {
        public object CreateController(ControllerContext context)
        {
            //context.HttpContext.Request.Headers.AcceptLanguage

            //context.HttpContext.Request.Path - this means Kent/Index
            // Kent/Index is split by "/" = ["Kent", "Index"]
            //0th Controller
            //1st is Method
            //"Kent" + "Controller" = KentController Class is searched in current project DLL
            //and using reflection the obejct of KentController is created 
            //and returned from here
            throw new NotImplementedException();
        }

        public void ReleaseController(ControllerContext context, object controller)
        {
            throw new NotImplementedException();
        }
    }
}
