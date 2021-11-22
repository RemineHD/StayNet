using StayNet.Server.Entities;

namespace StayNet.Server.Events
{
    public class ClientConnectingEvent : ServerNetEvent
    {
        public ClientConnectingEvent(Client client, ClientConnectionData connectionData)
        {
            Client = client;
            ConnectionData = connectionData;
        }

        public Client Client { get; private set; }
        public ClientConnectionData ConnectionData { get; private set; }
    }
}