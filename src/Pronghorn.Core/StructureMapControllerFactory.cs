using System;
using System.Web.Mvc;

namespace Pronghorn.Core
{
    public class StructureMapControllerFactory : IControllerFactory
    {
        private readonly ServiceLocator _locator;

        public StructureMapControllerFactory(ServiceLocator locator)
        {
            _locator = locator;
        }

        public IController CreateController(System.Web.Routing.RequestContext requestContext, string controllerName)
        {
            if(controllerName.Contains(".ico")) return null;
            var controller = _locator.ResolveWithKey<PronghornControllerBase>(string.Format("{0}Controller",controllerName));
            controller.Name = "From the factory";
            
            //requestContext.HttpContext.Response.Write(_locator.Container.WhatDoIHave().Replace("\r\n","<br/>"));
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