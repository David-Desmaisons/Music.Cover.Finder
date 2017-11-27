using System.Threading.Tasks;
using Music.Cover.Finder.Application.Navigation;
using Music.Cover.Finder.Application.WindowServices;
using Music.Cover.Finder.ViewModel.Modal;
using Neutronium.WPF.ViewModel;

namespace Music.Cover.Finder.ViewModel
{
    public class ApplicationViewModel : Vm.Tools.ViewModel, IMessageBox, INotificationSender
    {
        public ApplicationInformation ApplicationInformation { get; } = new ApplicationInformation();
        public IWindowViewModel Window { get; }
        public NavigationViewModel Router { get; }

        private object _CurrentViewModel;
        public object CurrentViewModel 
        {
            get { return _CurrentViewModel; }
            private set { Set(ref _CurrentViewModel, value); }
        }

        private MessageModalViewModel _Modal;
        public MessageModalViewModel Modal
        {
            get { return _Modal; }
            private set { Set(ref _Modal, value); }
        }

        private Notification _Notification = null;
        public Notification Notification
        {
            get { return _Notification; }
            set { Set(ref _Notification, value); }
        }

        public ApplicationViewModel(IWindowViewModel window, NavigationViewModel router)
        {
            Window = window;
            Router = router;
            Router.OnNavigated += Router_OnNavigated;
        }

        private void Router_OnNavigated(object sender, RoutedEventArgs e) 
        {
            CurrentViewModel = e.NewRoute.ViewModel;
        }

        public Task<bool> ShowMessage(ConfirmationMessage confirmationMessage)
        {
            var modal = new MainModalViewModel(confirmationMessage);
            Modal = modal;
            return modal.CompletionTask;
        }

        public void ShowInformation(MessageInformation messageInformation)
        {
            var modal = new MessageModalViewModel(messageInformation);
            Modal = modal;
        }

        public void Send(Notification notification)
        {
            Notification = notification;
        }
    }
}
