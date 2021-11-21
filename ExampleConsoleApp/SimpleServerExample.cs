using System.Net;
using System.Threading;
using StayNet;
using StayNet.Server.Enums;

namespace ExampleConsoleApp
{
    public class SimpleServerExample
    {
        
        public static void Run()
        {
            var config = new StayNetServerConfiguration
            {
                Host = IPAddress.Any,
                Port = 1444,
                MaxConnections = 10,
                LogLevel = LogLevel.Debug,
                Logger = new ConsoleLogger()
            };
            
            var server = new StayNetServer(config);
            
            server.Start();
            new Thread(() =>
            {
                while (true)
                {
                    Thread.Sleep(1000);
                }
            }).Start();
        }
        
    }
}