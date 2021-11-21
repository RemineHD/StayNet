namespace StayNet.Server.Events
{
    public abstract class ServerNetEvent
    {
        
        public bool IsHandled { get; private set; }
        public bool IsCanceled { get; private set; }
        
        internal ServerNetEvent()
        {
            
        }

        public void Cancel()
        {
            IsCanceled = true;
        }
        
        public void Handle()
        {
            IsHandled = true;
        }
        
    }
}