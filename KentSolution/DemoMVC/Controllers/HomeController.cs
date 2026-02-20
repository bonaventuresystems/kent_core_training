using DemoMVC.Models;
using DemoMVC.OMLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace DemoMVC.Controllers
{
    public class HomeController : Controller
    {
        OMEmp oMEmp = new OMEmp();
        public IActionResult Index()
        {
            var emps = oMEmp.GetEmps();
            return View(emps);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Emp emp)
        {
            oMEmp.AddEmp(emp);
            return Redirect("/Home/Index");
        }

        public IActionResult Edit(int? id)
        {
            Emp emp = oMEmp.GetEmp(id);
            return View(emp);
        }
        public IActionResult AfterEdit(Emp emp)
        {
            oMEmp.UpdateEmp(emp);
            return Redirect("/Home/Index");
        }
        public IActionResult Delete(int? id)
        {
            oMEmp.RemoveEmp(id);
            return Redirect("/Home/Index");
        }


    }
}
