using Grpc.Core;
using Ticker;

public class TickerServiceImpl : TickerService.TickerServiceBase
{
    public override async Task ChatTickerStream(
        IAsyncStreamReader<TickerMessage> requestStream,
        IServerStreamWriter<TickerMessage> responseStream,
        ServerCallContext context)
    {
        Console.WriteLine("🚀 SERVER: Bidirectional stream STARTED");
        Console.WriteLine("📡 SERVER: Listening for client messages...");

        var cts = CancellationTokenSource.CreateLinkedTokenSource(context.CancellationToken);
        bool paused = false;

        // Send initial welcome (SERVER → CLIENT)
        var welcomeMsg = new TickerMessage
        {
            Type = "ack",
            Timestamp = DateTime.UtcNow.ToString("O"),
            Command = "welcome"
        };
        await responseStream.WriteAsync(welcomeMsg);
        Console.WriteLine($"📤 SERVER → CLIENT: Sent welcome message");

        try
        {
            await foreach (var msg in requestStream.ReadAllAsync(cts.Token))
            {
                Console.WriteLine($"\n📥 CLIENT → SERVER: [{msg.Type}] {msg.Symbol ?? "N/A"} {msg.Price} '{msg.Command ?? "N/A"}'");

                if (msg.Type == "control")
                {
                    if (msg.Command == "pause")
                    {
                        paused = true;
                        Console.WriteLine("⏸️  SERVER: PAUSED receiving prices");
                    }
                    else if (msg.Command == "resume")
                    {
                        paused = false;
                        Console.WriteLine("▶️  SERVER: RESUMED receiving prices");
                    }
                    else if (msg.Command == "stop")
                    {
                        Console.WriteLine("🛑 SERVER: STOP command received");
                        cts.Cancel();
                        return;
                    }

                    // Echo control ack (SERVER → CLIENT)
                    var ackMsg = new TickerMessage
                    {
                        Type = "ack",
                        Command = $"control_{msg.Command}_ok",
                        Timestamp = DateTime.UtcNow.ToString("O")
                    };
                    await responseStream.WriteAsync(ackMsg);
                    Console.WriteLine($"📤 SERVER → CLIENT: Ack '{msg.Command}_ok'");
                }
                else if (msg.Type == "price" && !paused)
                {
                    Console.WriteLine($"💰 SERVER: Processing price {msg.Symbol} ${msg.Price:F2}");

                    // Echo price back (SERVER → CLIENT)
                    var priceEcho = new TickerMessage
                    {
                        Type = "ack",
                        Symbol = msg.Symbol,
                        Price = msg.Price,
                        Timestamp = msg.Timestamp
                    };
                    await responseStream.WriteAsync(priceEcho);
                    Console.WriteLine($"📤 SERVER → CLIENT: Echoed {msg.Symbol} ${msg.Price:F2}");
                }
                else if (msg.Type == "price" && paused)
                {
                    Console.WriteLine($"⏳ SERVER: IGNORED price {msg.Symbol} (PAUSED)");
                }
            }
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("🔌 SERVER: Stream cancelled by client");
        }

        Console.WriteLine("🏁 SERVER: Bidirectional stream COMPLETED");
    }
}
