using System.Web;
using StructureMap.Configuration.DSL;

namespace Pronghorn.Core
{
    public class ScanningRegistry : Registry, IScanningRegistry
    {
        public ScanningRegistry(HttpContext context)
        {
            Scan(context);
        }
        public void Scan(HttpContext context)
        {
            Scan(x =>
            {
                x.AssembliesFromPath(context.Server.MapPath("~/bin"));
                x.AddAllTypesOf<PronghornControllerBase>().NameBy(type => type.Name);
                x.WithDefaultConventions();
                x.AssembliesFromPath(context.Server.MapPath("~/Widgets"));
                x.AddAllTypesOf<WidgetBase>().NameBy(type => type.FullName);
            });
        }
    }
}