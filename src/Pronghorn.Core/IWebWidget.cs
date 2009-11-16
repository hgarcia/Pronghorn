namespace Pronghorn.Core
{
    public interface IWebWidget : IWIdget
    {
       string JsonParams { get; }
        void SetUp(WidgetJsonSetUpParams widgetJsonSetUpParams);       
    }
}