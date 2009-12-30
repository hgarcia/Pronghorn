using System.Web.Mvc;

namespace Pronghorn.Core
{
    public class CompositeController : Controller
    {
        private string _name = "";
        public string Name
        {
            get{ return _name;}
            set { _name = value; }
        }
    }
}