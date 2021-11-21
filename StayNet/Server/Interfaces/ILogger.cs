using StayNet.Server.Enums;

namespace StayNet.Server.Interfaces
{
    public interface ILogger
    {
        /// Create a log function for a specific type
        void Log(string message, LogLevel level, StayNetServer Server);
    }
}