namespace StayNet.Common.Attributes
{
    
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class Method : Attribute
    {
        public String MethodId { get; private set; }
        
        public Method(string Method)
        {
            MethodId = Method;
        }
    }
}