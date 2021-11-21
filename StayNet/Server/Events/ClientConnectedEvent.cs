using StayNet.Server.Entities;

namespace StayNet.Server.Events
{
    public class ClientConnectedEvent : ServerNetEvent
    {
        public ClientConnectedEvent(Client client, ClientConnectionData connectionData)
        {
            Client = client;
            ConnectionData = connectionData;
        }

        public Client Client { get; private set; }
        public ClientConnectionData ConnectionData { get; private set; }
    }
}