using System;

namespace Music.Cover.Finder.Application.Navigation
{
    public class NavigationContext
    {
        public string ResolutionKey { get; set; }
        public string RouteName { get; set; }
    }

    public class NavigationContext<T> : NavigationContext
    {
        public Action<T> BeforeNavigate { get; set; }
    }
}