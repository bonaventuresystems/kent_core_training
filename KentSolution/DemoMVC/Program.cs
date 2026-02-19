using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace DemoMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();//I need controllerFactory, ViewEngine

            var app = builder.Build(); //controllerFactory, ViewEngine objects are created here

            app.UseStaticFiles();
            //app.MapControllerRoute(
            // name: "myroute",
            // pattern: "{controller=Kent}/{action=Index}/{id?}/{name?}/{address?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }

   
}
