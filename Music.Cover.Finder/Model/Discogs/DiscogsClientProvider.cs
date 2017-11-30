using DiscogsClient;
using DiscogsClient.Internal;

namespace Music.Cover.Finder.Model.Discogs
{
    public class DiscogsClientProvider : IDiscogsClientProvider
    {
        private readonly IApplicationConfiguration _ApplicationConfiguration;

        public DiscogsClientProvider(IApplicationConfiguration applicationConfiguration)
        {
            _ApplicationConfiguration = applicationConfiguration;
        }

        public IDiscogsDataBaseClient GetDiscogsClient()
        {
            var tokenInformation = new TokenAuthenticationInformation(_ApplicationConfiguration.Token);
            return new DiscogsClient.DiscogsClient(tokenInformation);
        }
    }
}
