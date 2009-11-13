namespace Pronghorn.Core
{
    public class WidgetJsonSetUpParams
    {
        private readonly string _idModifier;
        private readonly string _design;
        private readonly string _jsonParams;
        private readonly IWidgetRepository _repository;
        //private readonly Site _site;

        public WidgetJsonSetUpParams(string idModifier, string design, string jsonParams, IWidgetRepository repository)//,Site site)
        {
            _idModifier = idModifier;
            _design = design;
            _jsonParams = jsonParams;
            _repository = repository;
            //_site = site;
        }

        /*
         public Site Site
         {
            get { return _site; }
         }
         */
        public string IdModifier
        {
            get { return _idModifier; }
        }

        public string Design
        {
            get { return _design; }
        }

        public string JsonParams
        {
            get { return _jsonParams; }
        }

        public IWidgetRepository Repository
        {
            get { return _repository; }
        }
    }
}