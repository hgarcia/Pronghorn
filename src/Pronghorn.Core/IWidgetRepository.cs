using System.Collections.Generic;

namespace Pronghorn.Core
{
    public interface IWidgetRepository
    {
        IEnumerable<TWidgetModel> GetWidgetModel<TWidgetParams, TWidgetModel>(TWidgetParams parameters);
        IList<IViewArea> GetAreasForUrl(string url, string id);
    }
}