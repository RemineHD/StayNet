using System.Net;
using StayNet;

namespace ExampleConsoleApp
{
    public class SimpleClientExample
    {
        public static void Run()
        {
            var config = new StayNetClientConfiguration();
            config.Logger = new ConsoleLogger();
            var client = new StayNetClient(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1444), config);
            client.Connect();
            
        }
    }
}