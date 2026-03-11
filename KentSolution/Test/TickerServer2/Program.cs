using Ticker;
using TickerServer2.Services;

namespace TickerServer2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddGrpc();

            var app = builder.Build();
            app.MapGrpcService<TickerServiceImpl>();
            app.Run("https://localhost:5001");
        }
    }
}