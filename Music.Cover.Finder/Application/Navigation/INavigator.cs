using System;
using System.Threading.Tasks;

namespace Music.Cover.Finder.Application.Navigation
{
    public interface INavigator
    {
        Task Navigate(object viewModel, string routeName = null);

        Task Navigate(string routeName);

        Task Navigate<T>(NavigationContext<T> context = null);

        Task Navigate(Type type, NavigationContext context = null);

        event EventHandler<RoutingEventArgs> OnNavigating;

        event EventHandler<RoutedEventArgs> OnNavigated;
    }
}