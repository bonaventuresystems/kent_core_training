using DemoEFMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Diagnostics;

namespace DemoEFMVC.Controllers
{
    public class DemoController : Controller
    {
        KentContext db = new KentContext(); 


        public IActionResult Create(int skip)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            //SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=Kent;Integrated Security=True;");
            //SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT  * FROM vw_ECommerceAnalytics", con);

            //dataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            //DataSet dataSet = new DataSet();
            //dataAdapter.Fill(dataSet, "vw_ECommerceAnalytics");

            //db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            db.VwEcommerceAnalytics.AsNoTracking();
         
            //var data =  db.VwEcommerceAnalytics.ToList();

            SqlParameter parameter = new SqlParameter("@records", SqlDbType.Int);
            parameter.Value = 100;
            var paged =  db.VwEcommerceAnalytics.FromSqlRaw("EXEC [dbo].[GetTopRecords] @records", parameter);
           //int skip = id;
            int take = 100;

            //var paged = data.Skip(skip * 100).Take(take).ToList();

            stopwatch.Stop();
            var timeTaken = stopwatch.ElapsedMilliseconds;

            ViewBag.timeTaken = timeTaken;

            //return View();
            return new JsonResult(paged.ToList()) ; //View();
        }


        [HttpPost]
        public IActionResult Create(Customer cust)
        {
            if(ModelState.IsValid)
            {
                //db.Customers.Add(cust);
                db.SaveChanges();
                return new ContentResult() { Content = "Done!" };
            }
            else
            {
                return View(cust);
            }
        
        }

    }
}
