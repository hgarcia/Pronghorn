
using System.Web.Mvc;
using Pronghorn.Core;

namespace Pronghorn.Web.Controllers
{
    [HandleError]
    public class HomeController : CompositeController
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC!" + this.Name;


            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
