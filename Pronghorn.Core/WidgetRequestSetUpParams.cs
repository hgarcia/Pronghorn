using System.Collections.Specialized;

namespace Pronghorn.Core
{
    public class WidgetRequestSetUpParams
    {
        private readonly string _idModifier;
        private readonly string _design;
        private readonly NameValueCollection _requestCollection;
        private readonly IWidgetRepository _repository;

        public WidgetRequestSetUpParams(string idModifier, string design, NameValueCollection requestCollection, IWidgetRepository repository)
        {
            _idModifier = idModifier;
            _design = design;
            _requestCollection = requestCollection;
            _repository = repository;
        }

        public string IdModifier
        {
            get { return _idModifier; }
        }

        public string Design
        {
            get { return _design; }
        }

        public NameValueCollection RequestCollection
        {
            get { return _requestCollection; }
        }

        public IWidgetRepository Repository
        {
            get { return _repository; }
        }
    }
}