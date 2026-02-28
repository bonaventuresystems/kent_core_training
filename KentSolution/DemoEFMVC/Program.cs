namespace DemoEFMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddCors((corsoptions) =>
            {
                corsoptions.AddPolicy("policy1", (policy) => {
                    policy.WithOrigins("*").WithMethods("*").WithHeaders("*");
                });

                corsoptions.AddPolicy("policy2", (policy) => {
                    policy.WithOrigins("amazon.com").WithMethods("GET, POST").WithHeaders("*");
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
            app.UseCors();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
