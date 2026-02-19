using DemoMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace DemoMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<Emp> emps = new List<Emp>();

            SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=KentDB;Integrated Security=True;");

            SqlCommand command = new SqlCommand("select * from Emp", connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Emp emp = new Emp();
                emp.No = Convert.ToInt32(reader["No"]);
                emp.Name = reader["Name"].ToString();
                emp.Address = reader["Address"].ToString();

                emps.Add(emp);
            }

            connection.Close();
           
            return View(emps);
        }
    }
}
