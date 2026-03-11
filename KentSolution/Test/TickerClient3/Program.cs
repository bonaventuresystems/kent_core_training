using Grpc.Core;
using Grpc.Net.Client;
using Ticker;

var channel = GrpcChannel.ForAddress("https://localhost:5001");
var client = new TickerService.TickerServiceClient(channel);

using var call = client.ChatTickerStream();

var readTask = Task.Run(async () =>
{
    await foreach (var msg in call.ResponseStream.ReadAllAsync())
    {
        Console.WriteLine($"Server: [{msg.Type}] {msg.Symbol ?? ""} {msg.Price} - {msg.Command ?? msg.Timestamp}");
    }
});

Console.WriteLine("Client: Connected. Sending commands: start, pause, resume, stop");

// Send initial start
await call.RequestStream.WriteAsync(new TickerMessage
{
    Type = "control",
    Command = "start",
    Timestamp = DateTime.UtcNow.ToString("O")
});

// Stream prices (runs concurrently with server responses)
var random = new Random();
var basePrice = 100.0;
var symbols = new[] { "AAPL", "GOOG", "MSFT" };

for (int i = 0; i < 30 && readTask.IsCompleted == false; i++)
{
    var symbol = symbols[random.Next(symbols.Length)];
    basePrice += (random.NextDouble() - 0.5) * 3;

    await call.RequestStream.WriteAsync(new TickerMessage
    {
        Type = "price",
        Symbol = symbol,
        Price = Math.Round(basePrice, 2),
        Timestamp = DateTime.UtcNow.ToString("O")
    });

    await Task.Delay(600);

    // Send pause/resume every 8 messages
    if (i % 8 == 7)
    {
        await call.RequestStream.WriteAsync(new TickerMessage
        {
            Type = "control",
            Command = (i / 8) % 2 == 0 ? "pause" : "resume",
            Timestamp = DateTime.UtcNow.ToString("O")
        });
    }
}

await call.RequestStream.WriteAsync(new TickerMessage
{
    Type = "control",
    Command = "stop",
    Timestamp = DateTime.UtcNow.ToString("O")
});

await call.RequestStream.CompleteAsync();
await readTask;

Console.ReadLine();
