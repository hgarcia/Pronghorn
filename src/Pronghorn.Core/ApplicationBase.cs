using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using StructureMap;

namespace Pronghorn.Core
{
    public abstract class ApplicationBase : HttpApplication
    {
        protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);
            ConfigureContainer();
        }

        public void ConfigureContainer()
        {
            ServiceLocator.SetLocatorProvider(new ServiceLocatorProvider(
                        new Container
                            (new ScanningRegistry(Context)
                            )
                           )
                          );
            ControllerBuilder.Current.SetControllerFactory(new StructureMapControllerFactory());
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