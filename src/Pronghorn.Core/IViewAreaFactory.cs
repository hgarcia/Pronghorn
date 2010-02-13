using System.Collections.Generic;
using System.Web.Routing;

namespace Pronghorn.Core
{
    public interface IViewAreaFactory
    {
        IList<IViewArea> GetViewAreas(Route route, SiteId siteId);
    }
}