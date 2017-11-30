using DiscogsClient;

namespace Music.Cover.Finder.Model.Discogs
{
    public interface IDiscogsClientProvider
    {
        IDiscogsDataBaseClient GetDiscogsClient();
    }
}