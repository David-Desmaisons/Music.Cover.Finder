namespace Music.Cover.Finder.Application.Navigation
{
    public struct BeforeRouterResult
    {
        private BeforeRouterResult(string redirect)
        {
            Redirect = redirect;
            Continue = true;
        }

        private BeforeRouterResult(bool continueRoute)
        {
            Continue = continueRoute;
            Redirect = null;          
        }

        public static BeforeRouterResult Cancel()
        {
            return new BeforeRouterResult(false);
        }

        public static BeforeRouterResult Ok()
        {
            return new BeforeRouterResult(true);
        }

        public static BeforeRouterResult CreateRedirect(string routeName)
        {
            return new BeforeRouterResult(routeName);
        }

        public string Redirect { get; }
        public bool Continue { get; }
    }
}
