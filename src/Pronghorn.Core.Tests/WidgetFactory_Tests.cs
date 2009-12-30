using NUnit.Framework;
using Pronghorn.Widgets;
using Rhino.Mocks;

namespace Pronghorn.Core.Tests
{
    [TestFixture]
    public class WidgetFactory_Tests
    {
        [Test]
        public void When_Given_a_Widget_Id_I_Should_Get_a_fully_initialized_Widget()
        {
            var widgetId = "Namespace.WidgetName";
            var serviceLocator = MockRepository.GenerateMock<IServiceLocatorProvider>();
            serviceLocator.Expect(s => s.ResolveWithKey<IWebWidget>(widgetId)).Return(new HelloWorldWebWidget());
            ServiceLocator.SetLocatorProvider(serviceLocator);

            IWidgetFactory widgetFactory = new WidgetFactory();

            widgetFactory.Create(widgetId);

            serviceLocator.VerifyAllExpectations();
        }
    }
}