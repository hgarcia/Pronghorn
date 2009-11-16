using System.Collections.Specialized;

namespace Pronghorn.Core
{
    public interface IServiceWidget : IWIdget
    {
        NameValueCollection QueryString { get; set; }
        void SetUp(WidgetRequestSetUpParams widgetRequestSetUpParams);
    }
}