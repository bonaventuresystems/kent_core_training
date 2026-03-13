using HRAPI.Models;
using Microsoft.OpenApi.Models;

namespace HRAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {

            //HR API
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<Jddb1Context>();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                                       builder =>
                                       {
                                           builder.AllowAnyOrigin()
                                                  .AllowAnyMethod()
                                                  .AllowAnyHeader();
                                       });
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                    c.RoutePrefix = "";
                });
            }


            app.UseCors();
   
            app.MapControllers();
            app.Run();

            //scaffold-dbcontext "Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=JDDB1;Integrated Security=True;" Microsoft.EntityFrameworkCore.SqlServer
        }
    }
}
