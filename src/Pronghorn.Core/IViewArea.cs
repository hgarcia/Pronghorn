using System.Collections.Generic;

namespace Pronghorn.Core
{
    public interface IViewArea
    {
        string Name { get; set; }
        IList<IWIdget> Widgets { get; set; }
    }
}