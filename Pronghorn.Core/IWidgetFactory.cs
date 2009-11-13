using System;

namespace Pronghorn.Core
{
    public interface IWidgetFactory
    {
        IWidget Create(string widgetId);
    }
}