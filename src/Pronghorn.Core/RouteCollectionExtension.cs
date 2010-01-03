using System;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;

namespace Pronghorn.Core
{
    public static class RouteCollectionExtension
    {
        public static void InsertRoute(this RouteCollection routes, int index, string routeName, Route newRoute)
        {
            var fieldInfo = routes.GetType()
                .GetField("_namedMap", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            var dict = fieldInfo.GetValue(routes);
            dict.GetType()
                .GetMethod("Add", BindingFlags.Public | BindingFlags.Instance)
                .Invoke(dict, new object[] { routeName, newRoute });

            fieldInfo.SetValue(routes, dict);

            routes.GetType()
                .GetMethod("InsertItem", BindingFlags.NonPublic | BindingFlags.Instance)
                .Invoke(routes, new object[] { index, newRoute });
        }

        public static void InsertRouteAfter(this RouteCollection routes, string nameOfExistingRoute, string nameOfRouteToInsert, Route newRoute)
        {
            var fieldInfo = routes.GetType()
                .GetField("_namedMap", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            var dict = fieldInfo.GetValue(routes);
            dict.GetType()
                .GetMethod("Add", BindingFlags.Public | BindingFlags.Instance)
                .Invoke(dict, new object[] { nameOfRouteToInsert, newRoute });

            var existingRoute = dict.GetType()
                .GetProperty("Item")
                .GetValue(dict, new[] { nameOfExistingRoute });

            fieldInfo.SetValue(routes, dict);

            var index = routes.GetType()
                .GetMethod("IndexOf", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .Invoke(routes, new[] { existingRoute });

            index = (int)index + 1;

            routes.GetType()
                .GetMethod("InsertItem", BindingFlags.NonPublic | BindingFlags.Instance)
                .Invoke(routes, new[] { index, newRoute });
        }

        public static Route InsertRouteAfter(this RouteCollection routes, string nameOfExistingRoute, string nameOfRouteToInsert, string url)
        {
            return routes.InsertRouteAfter(nameOfExistingRoute, nameOfRouteToInsert, url, null, null);
        }

        public static Route InsertRouteAfter(this RouteCollection routes, string nameOfExistingRoute, string nameOfRouteToInsert, string url, object defaults)
        {
            return routes.InsertRouteAfter(nameOfExistingRoute, nameOfRouteToInsert, url, defaults, null);
        }

        public static Route InsertRouteAfter(this RouteCollection routes, string nameOfExistingRoute, string nameOfRouteToInsert, string url, string[] namespaces)
        {
            return routes.InsertRouteAfter(nameOfExistingRoute, nameOfRouteToInsert, url, null, null, namespaces);
        }

        public static Route InsertRouteAfter(this RouteCollection routes, string nameOfExistingRoute, string nameOfRouteToInsert, string url, object defaults, object constraints)
        {
            return routes.InsertRouteAfter(nameOfExistingRoute, nameOfRouteToInsert, url, defaults, constraints, null);
        }

        public static Route InsertRouteAfter(this RouteCollection routes, string nameOfExistingRoute, string nameOfRouteToInsert, string url, object defaults, string[] namespaces)
        {
            return routes.InsertRouteAfter(nameOfExistingRoute, nameOfRouteToInsert, url, defaults, null, namespaces);
        }

        public static Route InsertRouteAfter(this RouteCollection routes, string nameOfExistingRoute, string nameOfRouteToInsert, string url, object defaults, object constraints, string[] namespaces)
        {
            if (routes == null)
            {
                throw new ArgumentNullException("routes");
            }
            if (url == null)
            {
                throw new ArgumentNullException("url");
            }
            var item = new Route(url, new MvcRouteHandler())
            {
                Defaults = new RouteValueDictionary(defaults),
                Constraints = new RouteValueDictionary(constraints),
                DataTokens = new RouteValueDictionary()
            };
            if ((namespaces != null) && (namespaces.Length > 0))
            {
                item.DataTokens["Namespaces"] = namespaces;
            }
            routes.InsertRouteAfter(nameOfExistingRoute, nameOfRouteToInsert, item);
            return item;
        }

        public static Route InsertRoute(this RouteCollection routes, int index, string name, string url)
        {
            return routes.InsertRoute(index, name, url, null, null);
        }

        public static Route InsertRoute(this RouteCollection routes, int index, string name, string url, object defaults)
        {
            return routes.InsertRoute(index, name, url, defaults, null);
        }

        public static Route InsertRoute(this RouteCollection routes, int index, string name, string url, string[] namespaces)
        {
            return routes.InsertRoute(index, name, url, null, null, namespaces);
        }

        public static Route InsertRoute(this RouteCollection routes, int index, string name, string url, object defaults, object constraints)
        {
            return routes.InsertRoute(index, name, url, defaults, constraints, null);
        }

        public static Route InsertRoute(this RouteCollection routes, int index, string name, string url, object defaults, string[] namespaces)
        {
            return routes.InsertRoute(index, name, url, defaults, null, namespaces);
        }

        public static Route InsertRoute(this RouteCollection routes, int index, string name, string url, object defaults, object constraints, string[] namespaces)
        {
            if (routes == null)
            {
                throw new ArgumentNullException("routes");
            }
            if (url == null)
            {
                throw new ArgumentNullException("url");
            }
            var item = new Route(url, new MvcRouteHandler())
            {
                Defaults = new RouteValueDictionary(defaults),
                Constraints = new RouteValueDictionary(constraints),
                DataTokens = new RouteValueDictionary()
            };
            if ((namespaces != null) && (namespaces.Length > 0))
            {
                item.DataTokens["Namespaces"] = namespaces;
            }
            routes.InsertRoute(index, name, item);
            return item;
        }
        
    }
}