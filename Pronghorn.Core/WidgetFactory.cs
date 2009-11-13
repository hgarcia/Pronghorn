namespace Pronghorn.Core
{
    public class WidgetFactory : IWidgetFactory
    {
        private readonly IServiceLocator _serviceLocator;

        public WidgetFactory(IServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }

        public IWidget Create(string widgetId)
        {
            IWidget widget = _serviceLocator.ResolveWithKey<IWidget>(widgetId);

            //var params =  new WidgetJsonSetUpParams()
            //widget.SetUp();
            return widget;
        }
    }
}