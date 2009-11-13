using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Pronghorn.Core
{
    public abstract class ApplicationBase : HttpApplication
    {
        protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);
            ConfigureContainer();
        }

        public static void ConfigureContainer()
        {
            ControllerBuilder.Current.SetControllerFactory(new StructureMapControllerFactory(new ServiceLocator(HttpContext.Current)));
        }
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default",                                              // Route name
                "{controller}/{action}/{id}",                           // URL with parameters
                new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
            );

        }
    }
}