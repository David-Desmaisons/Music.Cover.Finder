using System.Diagnostics;
using Neutronium.MVVMComponents.Relay;

namespace Music.Cover.Finder.ViewModel.Library
{
    public static class LinkCommand
    {
        private const string LinkForToken = "https://www.discogs.com/settings/developers";
        private const string LinkDiscogs = "https://www.discogs.com/";
        private const string LinkForNeutronium = "https://github.com/NeutroniumCore/Neutronium";
        private const string LinkForProduct = "https://github.com/David-Desmaisons/Music.Cover.Finder";

        public static RelaySimpleCommand GoToProduct { get; } = To(LinkForProduct);
        public static RelaySimpleCommand GoToLDiscogsForToken { get; } = To(LinkForToken);
        public static RelaySimpleCommand GoToDiscogs { get; } = To(LinkDiscogs);
        public static RelaySimpleCommand GoToNeutronium { get; } = To(LinkForNeutronium);


        private static RelaySimpleCommand To(string link) => new RelaySimpleCommand(() => Process.Start(link));
    }
}
