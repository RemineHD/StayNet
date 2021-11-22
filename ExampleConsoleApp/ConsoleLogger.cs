using StayNet;
using StayNet.Common.Enums;
using StayNet.Common.Interfaces;

namespace ExampleConsoleApp
{
    public class ConsoleLogger : ILogger
    {
        public void Log(string message, LogLevel level, StayNetServer Server)
        {
            //write message to console including the loglevel
            Console.WriteLine($"SERVER {level} - {message}");
        }
        
        public void Log(string message, LogLevel level, StayNetClient Client)
        {
            //write message to console including the loglevel
            Console.WriteLine($"CLIENT {level} - {message}");
        }
    }
}