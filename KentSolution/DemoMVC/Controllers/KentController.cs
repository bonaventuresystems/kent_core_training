using Microsoft.AspNetCore.Mvc;
using DemoMVC.Models;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DemoMVC.Controllers
{
    public class KentController : Controller
    {
        public IActionResult Index()
        {
            Emp emp = new Emp() { No = 1, Name = "Test", Address = "Pune" };
            //Customer customer = new Customer() { No = 11, Name = "Test1", Address = "Pune" };
            return View("MyView", emp); //View is searched by ViewEngine in specificfolders

            //return View("MyView", customer);
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



////public class RazorViewEngine : IViewEngine
//public class MyViewEngine : IViewEngine
//{

//    public ViewEngineResult FindView(ActionContext context, string viewName, bool isMainPage)
//    {
//        //in this a view by viewName is searched 
//        //in specific folders 
//        //Ex.
//        //RazorViewEngine searches for file with ViewName.CSHTML files 
//        //in /View/<ControllerName>/ location 
//        //or
//        ///View/Shared/ location 

//        throw new NotImplementedException();
//    }

//    public ViewEngineResult GetView(string? executingFilePath, string viewPath, bool isMainPage)
//    {
//        throw new NotImplementedException();
//    }
//}

//public class MyView : IView
//{
//    public string Path => throw new NotImplementedException();

//    public Task RenderAsync(ViewContext context)
//    {
//        throw new NotImplementedException();
//    }
//}

//public class MyViewEngine: VirtualPathEngine
//{

//}
