using System;
using System.ComponentModel;
using Music.Cover.Finder.Application.LifeCycleHook;
using Music.Cover.Finder.Application.Navigation;
using Music.Cover.Finder.Application.WindowServices;
using Music.Cover.Finder.Model;
using Music.Cover.Finder.ViewModel.Pages;

namespace Music.Cover.Finder
{
    public class ApplicationLifeCycle : IApplicationLifeCycle
    {
        private readonly IMessageBox _MessageBox;
        private readonly IApplicationConfiguration _ApplicationConfiguration;

        public ApplicationLifeCycle(IMessageBox messageBox, IApplicationConfiguration applicationConfiguration)
        {
            _MessageBox = messageBox;
            _ApplicationConfiguration = applicationConfiguration;
        }

        public void OnNavigating(RoutingEventArgs routingEvent)
        {
            var search = routingEvent.To.ViewModel as SearchViewModel;
            if (search == null)
                return;

            if (!String.IsNullOrEmpty(_ApplicationConfiguration.Token))
                return;

            routingEvent.RedirectToroute("authentication");

            var first = routingEvent.From.ViewModel == null;

            var confirmationMessage = BuildEmptyTokenMessage(first);
            _MessageBox.ShowInformation(confirmationMessage);
        }

        private static MessageInformation BuildEmptyTokenMessage(bool first)
        {
            return first? new MessageInformation(Resource.TokenNeeded, Resource.FirstTimeTokenMessage) : new MessageInformation(Resource.OperationNotAvailable, Resource.NeedToken);
        }

        public void OnNavigated(RoutedEventArgs routedEvent)
        {
        }

        public void OnClosing(CancelEventArgs cancelEvent)
        {
        }

        public void OnSessionEnding(CancelEventArgs cancelEvent)
        {
        }

        public void OnClosed()
        {
        }
    }
}
