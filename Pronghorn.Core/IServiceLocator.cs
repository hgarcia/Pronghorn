using System.Collections.Generic;
using StructureMap;

namespace Pronghorn.Core
{
    public interface IServiceLocator
    {
        Container Container { get; }
        TFacility Resolve<TFacility>();
        TFacility ResolveWithKey<TFacility>(string key);
        IList<TFacility> GetAllInstancesOf<TFacility>();
    }
}