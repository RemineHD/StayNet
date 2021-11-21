using System.IO;
using System.Text;

namespace StayNet.Server.Entities
{
    public sealed class ClientConnectionData
    {
        public MemoryStream Stream { get; private set; }
        
        public void Read(byte[] buffer, int offset, int count)
        {
            Stream.Read(buffer, offset, count);
        }
        
        public string ReadString()
        {
            //convert all memoryStream to a UTF-8 string
            byte[] bytes = Stream.ToArray();
            return Encoding.UTF8.GetString(bytes, 0, bytes.Length);
        }
    }
}