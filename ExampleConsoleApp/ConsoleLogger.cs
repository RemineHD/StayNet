using StayNet;
using StayNet.Server.Enums;
using StayNet.Server.Interfaces;

namespace ExampleConsoleApp
{
    public class ConsoleLogger : ILogger
    {
        public void Log(string message, LogLevel level, StayNetServer Server)
        {
            //write message to console including the loglevel
            Console.WriteLine($"{level} - {message}");
        }
    }
}