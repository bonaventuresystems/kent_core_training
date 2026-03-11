using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TickerServer
{
    using Grpc.Core;
    using Ticker;

    public class TickerServiceImpl : TickerService.TickerServiceBase
    {
        public override async Task GetTickerStream(TickerRequest request,
            IServerStreamWriter<TickerResponse> responseStream, ServerCallContext context)
        {
            var random = new Random();
            var basePrice = 100.0 + random.NextDouble() * 50;  // Random base ~$100-150

            while (!context.CancellationToken.IsCancellationRequested)
            {
                basePrice += (random.NextDouble() - 0.5) * 2;  // Simulate fluctuation
                var response = new TickerResponse
                {
                    Symbol = request.Symbol,
                    Price = Math.Round(basePrice, 2),
                    Timestamp = DateTime.UtcNow.ToString("O")
                };

                await responseStream.WriteAsync(response);
                await Task.Delay(1000, context.CancellationToken);  // 1s interval
            }
        }
    }
}
