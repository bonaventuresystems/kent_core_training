using Microsoft.AspNetCore.Mvc;
using DemoMVC.Models;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DemoMVC.Controllers
{

    public class KentController : BaseController
    {
        #region Old FilterCode
        //public override void OnActionExecuting(ActionExecutingContext context)
        //{
        //   //Logging related code 
        //}

        //public override void OnActionExecuted(ActionExecutedContext context)
        //{
        //    //Logging related code 
        //}

        #endregion
        public IActionResult Index()
        {
            Emp emp = new Emp() { No = 1, Name = "Test", Address = "Pune" };
            return View("MyView", emp); //View is searched by ViewEngine in specificfolders
            #region Old Code
            //Customer customer = new Customer() { No = 11, Name = "Test1", Address = "Pune" };
            //return View("MyView", customer);

            #endregion
        }

        public IActionResult AfterIndex([ModelBinder(typeof(MyModelBinder))]Emp emp)
        {
            return null;
        }

        public IActionResult Emps()
        {
            Emp emp1 = new Emp() { No = 11, Name = "Test1", Address = "Pune1" };
            Emp emp2 = new Emp() { No = 12, Name = "Test2", Address = "Pune2" };

            return new JsonResult(new List<Emp>() { emp1, emp2 });
        }
        public IActionResult About()
        {
            return View();
        }
    }

}

public class MyModelBinder : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        return Task.CompletedTask;
    }
}

#region OldCode


//namespace DemoMVC.Controllers.French
//{
//    public class KentController : Controller
//    {
//        public IActionResult Index()
//        {
//            Emp emp = new Emp() { No = 1, Name = "Test", Address = "Pune" };
//            return View("MyView", emp);
//        }
//    }
//}

#endregion

