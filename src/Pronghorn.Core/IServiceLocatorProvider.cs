using System.Collections.Generic;


namespace Pronghorn.Core
{
    public interface IServiceLocatorProvider
    {
        TFacility Resolve<TFacility>();
        TFacility ResolveWithKey<TFacility>(string key);
        IList<TFacility> GetAllInstancesOf<TFacility>();       
    }
}