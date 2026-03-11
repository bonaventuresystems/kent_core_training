using Grpc.Net.Client;

namespace GreeterServiceClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var client = new Greeter.GreeterClient(GrpcChannel.ForAddress("https://localhost:7141/"));
       
            var reply = client.SayHello(new HelloRequest { Name = "World" });

            Console.WriteLine("Greeting: " + reply.Message);

            Console.ReadLine();            
        }
    }
}
