using System.Threading.Tasks;
using StayNet.Common.Attributes;
using StayNet.Server.Controllers;

namespace ExampleConsoleApp
{
    
    public class SimpleController : BaseController
    {
        [Method("message")]
        public async Task Message(string text)
        {
            
        }
        
        
    }
}