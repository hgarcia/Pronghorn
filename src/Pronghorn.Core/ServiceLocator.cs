namespace Pronghorn.Core
{
    public class ServiceLocator
    {
        public static void SetLocatorProvider(IServiceLocatorProvider provider)
        {
            Current = provider;
        }

        public static IServiceLocatorProvider Current { get; private set; }
    }

}