using Grpc.Core;
using Ticker;

namespace TickerServer2.Services
{
    public class TickerServiceImpl : TickerService.TickerServiceBase
    {
        public override async Task<TickerRequest> SendTickerStream(
            IAsyncStreamReader<TickerResponse> requestStream, ServerCallContext context)
        {
            Console.WriteLine("Server: Waiting for client ticker stream...");

            var symbols = new HashSet<string>();
            await foreach (var ticker in requestStream.ReadAllAsync(context.CancellationToken))
            {
                Console.WriteLine($"Server received: {ticker.Symbol} ${ticker.Price:F2} at {ticker.Timestamp}");
                symbols.Add(ticker.Symbol);
            }

            Console.WriteLine($"Server processed {symbols.Count} unique symbols.");
            return new TickerRequest { Symbol = $"Processed: {string.Join(", ", symbols)}" };
        }
    }
}
