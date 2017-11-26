using System.ComponentModel;
using Music.Cover.Finder.Application.Navigation;

namespace Music.Cover.Finder.Application.LifeCycleHook
{
    public interface IApplicationLifeCycle
    {
        void OnNavigating(RoutingEventArgs routingEvent);

        void OnNavigated(RoutedEventArgs routedEvent);

        void OnClosing(CancelEventArgs cancelEvent);

        void OnSessionEnding(CancelEventArgs cancelEvent);

        void OnClosed();
    }
}
