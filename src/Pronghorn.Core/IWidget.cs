using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Pronghorn.Core
{
    public interface IWidget
    {
        IEnumerable<T> GetModel<T>();
        IEnumerable GetModel();
        string IdModifier { get; }
        string Design { get; }
        string JsonParams { get; }
        NameValueCollection QueryString { get; set; }

        void SetUp(WidgetJsonSetUpParams widgetJsonSetUpParams);
        void SetUp(WidgetRequestSetUpParams widgetRequestSetUpParams);
    }
}