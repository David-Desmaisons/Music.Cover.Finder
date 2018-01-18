using System;
using Microsoft.Practices.ServiceLocation;
using Music.Cover.Finder.Application.LifeCycleHook;
using Music.Cover.Finder.Application.Navigation;
using Music.Cover.Finder.Application.WindowServices;
using Music.Cover.Finder.ViewModel;
using Neutronium.WPF.ViewModel;

namespace Music.Cover.Finder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private LifeCycleEventsRegistror _LifeCycleEventsRegistror;

        public MainWindow()
        {
            Initialized += MainWindow_Initialized;
            InitializeComponent();
        }

        private void MainWindow_Initialized(object sender, EventArgs e)
        {
            DataContext = BuildApplicationViewModel();
        }

        private ApplicationViewModel BuildApplicationViewModel()
        {
            var window = new WindowViewModel(this);
            var routeSolver = RoutingConfiguration.Register();
            var serviceLocatorBuilder = new DependencyInjectionConfiguration();
            var serviceLocator = serviceLocatorBuilder.GetServiceLocator();

            var navigation = NavigationViewModel.Create(serviceLocator, routeSolver);

            serviceLocatorBuilder.Register<IWindowViewModel>(window);
            serviceLocatorBuilder.Register<INavigator>(navigation);
            serviceLocatorBuilder.Register(navigation);

            var application = serviceLocator.GetInstance<ApplicationViewModel>();
            serviceLocatorBuilder.Register<IMessageBox>(application);
            serviceLocatorBuilder.Register<INotificationSender>(application);

            _LifeCycleEventsRegistror = RegisterLifeCycleEvents(serviceLocator);

            return application;
        }

        private LifeCycleEventsRegistror RegisterLifeCycleEvents(IServiceLocator serviceLocator)
        {
            var registor = serviceLocator.GetInstance<LifeCycleEventsRegistror>();
            return registor.Register();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            this.HtmlView.Dispose();
        }
    }
}
