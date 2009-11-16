using System.Collections;
using System.Collections.Generic;

namespace Pronghorn.Core
{
    public interface IWIdget
    {
        IEnumerable<T> GetModel<T>();
        IEnumerable GetModel();
        string IdModifier { get; }
        string Design { get; }  
    }
}