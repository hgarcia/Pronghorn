namespace Pronghorn.ViewEngine
{
    public interface ILocalizationService
    {
        string GetPhrase(string key, string language);
    }
}