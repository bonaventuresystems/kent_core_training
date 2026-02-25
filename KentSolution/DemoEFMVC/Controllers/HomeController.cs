using DemoEFMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoEFMVC.Controllers
{
    public class HomeController : Controller
    {
        KentContext db = new KentContext(); 

        public IActionResult Index()
        {



            //var customers = db.Customers.ToList();
            return View(db.Emps.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Emp emp)
        {
            if(ModelState.IsValid)
            {
                db.Emps.Add(emp);
                db.SaveChanges();
                return Redirect("/Home/Index");
            }
            else
            {
                return View(emp);
            }
        
        }

        public IActionResult Edit(int? id)
        {
            Emp emp = db.Emps.Find(id);
            return View(emp);
        }
        public IActionResult AfterEdit(Emp emp)
        {
            Emp empToBeUpdated = db.Emps.Find(emp.No);
            empToBeUpdated.Name = emp.Name;
            empToBeUpdated.Address = emp.Address;
            db.SaveChanges();
            return Redirect("/Home/Index");
        }
        public IActionResult Delete(int? id)
        {
            Emp empToBeDeleted = db.Emps.Find(id);
            db.Emps.Remove(empToBeDeleted);
            db.SaveChanges();
            return Redirect("/Home/Index");
        }
    }
}
