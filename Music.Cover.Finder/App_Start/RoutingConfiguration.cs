using Neutronium.Core.Navigation.Routing;
using Music.Cover.Finder.Application.Navigation;

namespace Music.Cover.Finder
{
    public class RoutingConfiguration
    {
        public static IRouterSolver Register()
        {
            var router = new Router();
            BuildRoutes(router);
            return router;
        }

        private static void BuildRoutes(IRouterBuilder routeBuilder)
        {
            var convention = routeBuilder.GetTemplateConvention("{vm}");
            typeof(RoutingConfiguration).GetTypesFromSameAssembly()
                .InNamespace("Music.Cover.Finder.ViewModel.Pages")
                .Register(convention);
        }
    }
}
