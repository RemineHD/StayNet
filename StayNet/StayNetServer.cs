using System.Reflection;
using StayNet.Server.Controllers;

namespace StayNet
{
    public sealed class StayNetServerConfiguration
    {
        public string Host { get; set; } 
        public int Port { get; set; }
        
        public IServiceProvider ServiceProvider { get; set; }
    }
    public sealed class StayNetServer
    {

        #region Events
        
        public event EventHandler<ClientConnectedEvent> ClientConnected;
        public event EventHandler<ClientDisconnectedEvent> ClientDisconnected;
        public event EventHandler<ClientConnectingEvent> ClientConnecting;
        
        #endregion
        
        public readonly StayNetServerConfiguration Configuration;
        public StayNetServer(StayNetServerConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public void RegisterController<T>()  where T : BaseController
        {
        }

        public void RegisterControllers(Assembly assembly)
        {
            
        }
        
        
        
    }

}