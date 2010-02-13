using System.Web.Mvc;
using System.Web.Routing;

namespace Pronghorn.Core
{
    public class CompositeController : Controller
    {
        private IViewAreaFactory _viewAreaFactory;

        public CompositeController(IViewAreaFactory viewAreaFactory)
        {
            _viewAreaFactory = viewAreaFactory;
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            ((ICompositeModel) ViewData.Model).ViewAreas = _viewAreaFactory.GetViewAreas((Route)filterContext.RouteData.Route, new SiteId("sureflix.com"));
            base.OnActionExecuted(filterContext);
        }
    }
}