using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace DemoMVC
{
    public class Program
    {
        public static void Main(string[] args)
        
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();//I need controllerFactory, ViewEngine

            var app = builder.Build(); //controllerFactory, ViewEngine objects are created here

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }

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
