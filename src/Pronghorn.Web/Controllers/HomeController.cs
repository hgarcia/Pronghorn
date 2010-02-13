
using System.Web.Mvc;
using Pronghorn.Core;

namespace Pronghorn.Web.Controllers
{
    [HandleError]
    public class HomeController : CompositeController
    {
        public HomeController(IViewAreaFactory viewAreaFactory) : base(viewAreaFactory)
        {
        }

        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC!";


            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
