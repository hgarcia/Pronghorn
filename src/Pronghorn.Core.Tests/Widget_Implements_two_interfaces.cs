using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace Pronghorn.Core.Tests
{
    [TestFixture]
    public class Widget_Implements_two_interfaces
    {
        [Test]
        public void When_calling_an_IWebWidget_Should_be_able_to_instantiate_a_WebWidgetBase()
        {
            var webWidget = new WebWidgetFromBase();
            Assert.That(webWidget, Is.AssignableTo(typeof(IWebWidget)));
        }

        [Test]
        public void When_calling_an_IServiceWidget_Should_be_able_to_instantiate_a_ServiceWidgetBase()
        {
            var serviceWidget = new ServiceWidgetFromBase();
            Assert.That(serviceWidget,Is.AssignableTo(typeof(IServiceWidget)));
        }
    }

    public class ServiceWidgetFromBase :  ServiceWidgetBase
    {
        public override IEnumerable<T> GetModel<T>()
        {
            throw new NotImplementedException();
        }

        public override IEnumerable GetModel()
        {
            throw new NotImplementedException();
        }
    }

    public class WebWidgetFromBase : WebWidgetBase
    {
        public override IEnumerable<T> GetModel<T>()
        {
            throw new NotImplementedException();
        }

        public override IEnumerable GetModel()
        {
            throw new NotImplementedException();
        }
    }
}