namespace StayNet.Server.Exceptions
{
    public class ServerStateException : Exception
    {
        public StayNetServer Server { get; private set; }
        
        internal ServerStateException(string message, StayNetServer Server) : base(message)
        {
            this.Server = Server;
        }
        
    }
}