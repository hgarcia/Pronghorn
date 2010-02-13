using System;
using System.Web.Mvc;

namespace Pronghorn.Core
{
    public class StructureMapControllerFactory : IControllerFactory
    {
        public IController CreateController(System.Web.Routing.RequestContext requestContext, string controllerName)
        {
            if(controllerName.Contains(".ico")) return null;
            var controller = ServiceLocator.Current.ResolveWithKey<CompositeController>(string.Format("{0}Controller",controllerName));
            
            //requestContext.HttpContext.Response.Write(ServiceLocator.Current.WhatDoIHave().Replace("\r\n","<br/>"));
            //requestContext.HttpContext.Response.Write(requestContext.HttpContext.Server.MapPath("~/Widgets"));
            return controller;
        }

        public void ReleaseController(IController controller)
        {
            if (controller is IDisposable)
            {
                ((IDisposable) controller).Dispose();
            }
        }
    }
}