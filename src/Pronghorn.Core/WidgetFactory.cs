namespace Pronghorn.Core
{
    public class WidgetFactory : IWidgetFactory
    {
        private readonly IServiceLocator _serviceLocator;

        public WidgetFactory(IServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }

        public IWebWidget Create(string widgetId)
        {
            IWebWidget webWidget = _serviceLocator.ResolveWithKey<IWebWidget>(widgetId);

            //var params =  new WidgetJsonSetUpParams()
            //webWidget.SetUp();
            return webWidget;
        }
    }
}