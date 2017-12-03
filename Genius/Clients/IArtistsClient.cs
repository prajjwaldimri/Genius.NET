using System.Collections.Generic;
using System.Threading.Tasks;
using Genius.Models;

namespace Genius.Clients
{
    /// <summary>
    ///     An artist is how Genius represents the creator of one or more songs (or other documents hosted on Genius).
    ///     https://docs.genius.com/#artists-h2
    /// </summary>
    public interface IArtistsClient
    {
        Task<HttpResponse<Artist>> GetArtist(TextFormat textFormat, string artistId);

        Task<HttpResponse<List<Song>>> GetSongsByArtist(TextFormat textFormat, string artistId,
            string sort = "", string perPage = "", string page = "");
    }
}