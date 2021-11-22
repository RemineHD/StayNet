using System.Linq;
using System.Threading.Tasks;
using StayNet.Common.Attributes;

namespace StayNet.Server.Controllers
{
    public abstract class BaseController
    {
        
        public virtual async Task BeforeMethodInvoke(object context)
        {
            await Task.CompletedTask;
        }

        
    }
}