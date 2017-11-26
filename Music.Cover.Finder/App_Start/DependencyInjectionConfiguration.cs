using System;
using CommonServiceLocator.NinjectAdapter.Unofficial;
using Microsoft.Practices.ServiceLocation;
using Neutronium.Core.WebBrowserEngine.Window;
using Music.Cover.Finder.Application.LifeCycleHook;
using Music.Cover.Finder.Model;
using Music.Cover.Finder.Model.Persistency;
using Music.Cover.Finder.ViewModel.Pages;
using Neutronium.WPF.Internal;
using Ninject;
using Vm.Tools.Application;

namespace Music.Cover.Finder
{
    public class DependencyInjectionConfiguration : IDependencyInjectionConfiguration
    {
        private readonly StandardKernel _Kernel;
        private readonly Lazy<IServiceLocator> _ServiceLocator;

        public DependencyInjectionConfiguration()
        {
            var kernel = new StandardKernel(new NinjectSettings { UseReflectionBasedInjection = true });
            RegisterDependency(kernel);
            _Kernel = kernel;
            _ServiceLocator = new Lazy<IServiceLocator>(() => new NinjectServiceLocator(_Kernel));
        }

        public IServiceLocator GetServiceLocator() => _ServiceLocator.Value;

        public void Register<T>(T implementation) => _Kernel.Bind<T>().ToConstant(implementation);

        public static void RegisterDependency(IKernel kernel)
        {
            var window = System.Windows.Application.Current.MainWindow;
            var application = new WpfApplication(window);
            kernel.Bind<IApplication>().ToConstant(application);
            kernel.Bind<IDispatcher>().ToConstant(new WPFUIDispatcher(window.Dispatcher));
            kernel.Bind<IApplicationLifeCycle>().To<ApplicationLifeCycle>();
            kernel.Bind<IApplicationConfiguration>().To<MemoryApplicationConfiguration>().InSingletonScope();
            kernel.Bind<SearchViewModel>().ToSelf().InSingletonScope();
        }
    }
}
