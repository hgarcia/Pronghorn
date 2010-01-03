using System.Collections.ObjectModel;
using System.Web.Mvc;
using System.Web.Routing;
using NUnit.Framework;

namespace Pronghorn.Core.Tests
{
    [TestFixture]
    public class RouteCollectionExtensionTests
    {
        [Test]
        public void When_Adding_a_new_item_with_index_0_Should_Add_the_item_at_the_beginning_of_the_collection()
        {
            var col = new Collection<string>();

            col.Add("1");
            col.Add("2");
            col.Add("3");

            col.Insert(0, "4");

            Assert.That(col[0], Is.EqualTo("4"));
        }

        [Test]
        public void When_Adding_a_route_Should_be_added_at_the_beginning()
        {
            var routecollection = new RouteCollection();

            routecollection.MapRoute("first", "first");
            routecollection.MapRoute("second", "second");

            routecollection.InsertRoute(1, "area", new Route("area", new MvcRouteHandler()));

            Assert.That(routecollection.Count, Is.EqualTo(3));
        }

        [Test]
        public void When_Adding_a_route_after_an_existing_one_Should_be_added_at_the_existing_route_plus_one()
        {
            var routecollection = new RouteCollection();

            routecollection.MapRoute("first", "first");
            routecollection.MapRoute("second", "second");
            routecollection.MapRoute("third", "third");
            routecollection.MapRoute("fourth", "fourth");

            routecollection.InsertRouteAfter("fourth", "area", new Route("area", new MvcRouteHandler()));

            Assert.That(routecollection.Count, Is.EqualTo(5));
        }        
    }
}