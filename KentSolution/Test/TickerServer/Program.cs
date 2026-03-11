using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace TickerServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddGrpc();
            var app = builder.Build();
            app.MapGrpcService<TickerServiceImpl>();
            app.Run("https://localhost:5000");

            Console.WriteLine("server started");
            Console.ReadLine();
        }
    }
}
