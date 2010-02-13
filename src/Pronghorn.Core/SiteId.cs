namespace Pronghorn.Core
{
    public class SiteId
    {
        public SiteId(string siteId)
        {
            Id = siteId;
        }
        public string Id { get; private set; }
    }
}