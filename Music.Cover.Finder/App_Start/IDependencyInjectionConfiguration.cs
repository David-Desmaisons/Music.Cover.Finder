using Microsoft.Practices.ServiceLocation;

namespace Music.Cover.Finder
{
    public interface IDependencyInjectionConfiguration
    {
        IServiceLocator GetServiceLocator();

        void Register<T>(T implementation);
    }
}