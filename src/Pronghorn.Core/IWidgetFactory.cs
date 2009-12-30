namespace Pronghorn.Core
{
    public interface IWidgetFactory
    {
        IWebWidget Create(string widgetId);
    }
}