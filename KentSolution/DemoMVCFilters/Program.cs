using DemoMVCFilters.Filters;
using DemoMVCFilters.Models;

namespace DemoMVCFilters
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            builder.Services.AddSession();
            builder.Services.AddExceptionHandler<CommonExcpetionHandler>();
            //builder.Services.AddScoped<ISpellChecker, EnglishSpellChecker>();

            //builder.Services.AddSingleton<ISpellChecker, EnglishSpellChecker>();

            builder.Services.AddScoped<ISpellChecker, EnglishSpellChecker>();
            builder.Services.AddScoped<ISpellChecker, HindiSpellChecker>();
            var app = builder.Build();

            //if (!app.Environment.IsDevelopment())
            //{
                app.UseExceptionHandler("/Error/Handle");
            //}
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();
            //app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Test}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
