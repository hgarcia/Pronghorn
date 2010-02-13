using System.Collections.Generic;
using System.Web.Routing;

namespace Pronghorn.Core.Tests
{
    public class ViewAreaFactory : IViewAreaFactory
    {
        private readonly IWidgetRepository _widgetRepository;

        public ViewAreaFactory(IWidgetRepository widgetRepository)
        {
            _widgetRepository = widgetRepository;
        }

        public IList<IViewArea> GetViewAreas(Route route, SiteId siteId)
        {
            return _widgetRepository.GetAreasForUrl(route.Url, siteId.Id);
        }
    }
}