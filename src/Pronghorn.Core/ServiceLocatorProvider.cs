using System.Collections.Generic;
using StructureMap;

namespace Pronghorn.Core
{
    public class ServiceLocatorProvider : IServiceLocatorProvider
    {
        private static Container _container;

        public ServiceLocatorProvider(Container container)
        {
            _container = container;
        }

        public TFacility Resolve<TFacility>()
        {
            return _container.GetInstance<TFacility>();
        }

        public TFacility ResolveWithKey<TFacility>(string key)
        {
            return _container.GetInstance<TFacility>(key);
        }

        public IList<TFacility> GetAllInstancesOf<TFacility>()
        {
            return _container.GetAllInstances<TFacility>();
        }
    }
}