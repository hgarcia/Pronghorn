using System.Collections.Generic;
using System.Web;
using StructureMap;

namespace Pronghorn.Core
{
    public class ServiceLocator : IServiceLocator
    {
        private static Container _container;
        public ServiceLocator(HttpContext context)
        {
            _container = new Container(new ScanningRegistry(context));
        }

        public Container Container
        {
            get { return _container; }
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