using NUnit.Framework;
using Rhino.Mocks;

namespace Pronghorn.Core.Tests
{
    [TestFixture]
    public class WidgetFactoryTests
    {
        [Test]
        public void When_Given_a_Widget_Id_I_Should_Get_a_fully_initialized_Widget()
        {
            var widgetId = "Namespace.WidgetName";
            var serviceLocator = MockRepository.GenerateStub<IServiceLocator>();
            IWidgetFactory widgetFactory = new WidgetFactory(serviceLocator);

            IWidget widget = widgetFactory.Create(widgetId);
        }
    }
}