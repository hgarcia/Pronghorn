using System.Web;

namespace Pronghorn.Core
{
    public interface IScanningRegistry
    {
        void Scan(HttpContext context);
    }
}