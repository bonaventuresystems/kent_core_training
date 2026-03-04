using DemoMVCFilters.Filters;

namespace DemoMVCFilters
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            builder.Services.AddExceptionHandler<CommonExcpetionHandler>();

            var app = builder.Build();

            //if (!app.Environment.IsDevelopment())
            //{
                app.UseExceptionHandler("/Error/Handle");
            //}
            app.UseStaticFiles();

            app.UseRouting();

            //app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Demo}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
