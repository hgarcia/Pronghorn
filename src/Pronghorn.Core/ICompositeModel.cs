using System.Collections.Generic;

namespace Pronghorn.Core
{
    public interface ICompositeModel
    {
        IList<IViewArea> ViewAreas { get; set; }
    }
}