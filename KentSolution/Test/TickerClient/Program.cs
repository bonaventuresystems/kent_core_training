using Grpc.Core;
using Grpc.Net.Client;

namespace TickerClient
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            var channel = GrpcChannel.ForAddress("https://localhost:5000");
            var client = new Ticker.TickerService.TickerServiceClient(channel);

            var request = new Ticker.TickerRequest { Symbol = "AAPL" };
            Console.WriteLine($"Streaming ticker for {request.Symbol}...");

            using var stream = client.GetTickerStream(request);
            await foreach (var response in stream.ResponseStream.ReadAllAsync())
            {
                Console.WriteLine($"{response.Symbol}: ${response.Price} at {response.Timestamp}");
            }

            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();
        }
    }
}
