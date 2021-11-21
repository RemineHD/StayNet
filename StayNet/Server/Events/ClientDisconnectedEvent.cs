namespace StayNet.Server.Events
{
    public class ClientDisconnectedEvent : ServerNetEvent
    {
        
        
        public ClientDisconnectedEvent(Client client, bool wasKicked, string kickReason)
        {
            Client =  client;  
            WasKicked = wasKicked;
            KickReason = kickReason;
            
        }

        public Client Client { get; private set; }
        
        public bool WasKicked { get; private set; }
        
        public string KickReason { get; private set; }
        
        
    }
}