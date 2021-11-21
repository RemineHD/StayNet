using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using StayNet.Server;
using StayNet.Server.Controllers;
using StayNet.Server.Enums;
using StayNet.Server.Events;
using StayNet.Server.Exceptions;
using StayNet.Server.Interfaces;

namespace StayNet
{
    public sealed class StayNetServerConfiguration
    {
        public IPAddress Host { get; set; } 
        public int Port { get; set; }
        public IServiceProvider ServiceProvider { get; set; }
        public ILogger Logger { get; set; }
        public LogLevel LogLevel = LogLevel.Info;
        public int MaxConnections = 0;
    }
    public sealed class StayNetServer : IDisposable
    {

        #region Events
        
        public event EventHandler<Client> ClientConnected;
        public event EventHandler<ClientDisconnectedEvent> ClientDisconnected;
        public event EventHandler<ClientConnectedEvent> ClientConnecting;

        #endregion

        #region Public

        public readonly StayNetServerConfiguration Configuration;
        public bool IsRunning { get; private set; }
        
        #endregion

        #region Internal

        internal TcpListener m_listener;

        internal CancellationTokenSource m_cancellation;
        
        internal void Log(LogLevel level, string message)
        {
            if (Configuration.LogLevel <= level)
            {
                Configuration.Logger?.Log(message, level, this);
            }
        }
        
        #endregion

        public StayNetServer(StayNetServerConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        #region Methods

        public void Start()
        {
            if (IsRunning)
            {
                throw new ServerStateException("The server is already running!", this);
            }
            m_cancellation = new CancellationTokenSource();
            m_listener = new TcpListener(Configuration.Host, Configuration.Port);
            m_listener.Start();
            Task.Run(AcceptClientsAsync);
            Log(LogLevel.Info, "Server Started Successfully");
        }

        internal async Task AcceptClientsAsync()
        {
            Log(LogLevel.Debug, $"Listening task started. [{Thread.CurrentThread.ManagedThreadId}]");
            
            while (!m_cancellation.Token.IsCancellationRequested)
            {

                try
                {
                    TcpClient endClient = await m_listener.AcceptTcpClientAsync();
                    Log(LogLevel.Debug, $"Client starting connection");
                }
                catch (Exception e)
                {
                    Log(LogLevel.Debug, $"Client connection failed. {e.Message}");
                }
                
            }
        }

        public void RegisterController<T>()  where T : BaseController
        {
        }

        public void RegisterControllers(Assembly assembly)
        {
            
        }

        public void Dispose()
        {
            //Listener.Stop();
        }

        #endregion
    }

}