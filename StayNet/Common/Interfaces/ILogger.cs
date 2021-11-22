using StayNet.Common.Enums;

namespace StayNet.Common.Interfaces
{
    public interface ILogger
    {
        /// Create a log function for a specific type
        void Log(string message, LogLevel level, StayNetServer Server) {}
        void Log(string message, LogLevel level, StayNetClient Client) {}
    }
}