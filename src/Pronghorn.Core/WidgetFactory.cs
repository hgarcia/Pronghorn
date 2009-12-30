namespace Pronghorn.Core
{
    public class WidgetFactory : IWidgetFactory
    {
        public IWebWidget Create(string widgetId)
        {
            var webWidget = ServiceLocator.Current.ResolveWithKey<IWebWidget>(widgetId);

            //var params =  new WidgetJsonSetUpParams()
            //webWidget.SetUp();
            return webWidget;
        }
    }
}