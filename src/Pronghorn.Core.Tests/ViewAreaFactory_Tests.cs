using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using NUnit.Framework;
using Rhino.Mocks;

namespace Pronghorn.Core.Tests
{
    [TestFixture]
    public class ViewAreaFactory_Tests
    {
        [Test]
        public void When_Calling_Get_areas_Should_return_a_list_of_areas_for_the_given_route()
        {
            var widgetRepository = MockRepository.GenerateStub<IWidgetRepository>();
            widgetRepository.Expect(w => w.GetAreasForUrl("Home/Index", "sureflix.com")).Return(new List<IViewArea> {new ViewArea()});

            IViewAreaFactory viewAreaFactory = new ViewAreaFactory(widgetRepository);
            var route = new Route("Home/Index", new MvcRouteHandler());
            
            var arealist = viewAreaFactory.GetViewAreas(route, new SiteId("sureflix.com"));
            Assert.That(arealist.Count,Is.GreaterThan(0));
        }
    }
}