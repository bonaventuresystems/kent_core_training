using Grpc.Net.Client;
using Ticker;

namespace TickerClient2
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new TickerService.TickerServiceClient(channel);

            using var call = client.SendTickerStream();
            Console.WriteLine("Client: Streaming ticker data to server...");

            var random = new Random();
            var basePrice = 100.0;
            var symbols = new[] { "AAPL", "GOOG", "MSFT" };

            for (int i = 0; i < 15; i++)
            {
                var symbol = symbols[random.Next(symbols.Length)];
                basePrice += (random.NextDouble() - 0.5) * 4;

                var ticker = new TickerResponse
                {
                    Symbol = symbol,
                    Price = Math.Round(basePrice + random.NextDouble() * 10, 2),
                    Timestamp = DateTime.UtcNow.ToString("O")
                };

                await call.RequestStream.WriteAsync(ticker);
                Console.WriteLine($"Client sent: {ticker.Symbol} ${ticker.Price:F2} at {ticker.Timestamp}");
                await Task.Delay(800);
            }

            Console.WriteLine("Client: Completed stream, waiting for server ack...");
            await call.RequestStream.CompleteAsync();

            var response = await call.ResponseAsync;
            Console.WriteLine($"Server ack: {response.Symbol}");

            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();
        }
    }
}
