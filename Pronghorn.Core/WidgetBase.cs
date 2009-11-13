using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Pronghorn.Core
{
    public abstract class WidgetBase : IWidget
    {
        public string IdModifier { get; private set; }
        public string Design { get; private set; }
        public string JsonParams { get; private set; }
        public NameValueCollection QueryString { get; set; }

        public virtual void SetUp(WidgetJsonSetUpParams widgetJsonSetUpParams)
        {
            IdModifier = widgetJsonSetUpParams.IdModifier;
            Design = widgetJsonSetUpParams.Design;
            Repository = widgetJsonSetUpParams.Repository;
            JsonParams = widgetJsonSetUpParams.JsonParams;
            //Site = site;
        }      

        public virtual void SetUp(WidgetRequestSetUpParams widgetRequestSetUpParams)
        {
            IdModifier = widgetRequestSetUpParams.IdModifier;
            Design = widgetRequestSetUpParams.Design;
            Repository = widgetRequestSetUpParams.Repository;
            QueryString = widgetRequestSetUpParams.RequestCollection;
            //Site = site;
        }
        
        public abstract IEnumerable<T> GetModel<T>();
        public abstract IEnumerable GetModel();
        public IWidgetRepository Repository { get; private set; }
        //public Site Site { get; set; }

        public virtual TWidgetParams GetParametersFromJson<TWidgetParams>()
        {
            if (string.IsNullOrEmpty(JsonParams)) return default(TWidgetParams);
            //return ToJson.JsonToGeneric<TWidgetParams>(JsonParams);
            return default(TWidgetParams);
        }

        public virtual TWidgetParams GetParametersFromQs<TWidgetParams>() where TWidgetParams : class, new()
        {
            //return Utils.MapCollectionToObject<TWidgetParams>(RequestCollection);
            return default(TWidgetParams);
        }
    }
}