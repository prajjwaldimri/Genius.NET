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
        /// <summary>
        ///     Retrieves data for a specific Artist.
        /// </summary>
        /// <param name="textFormat">Format for text bodies related to the document</param>
        /// <param name="artistId">ID of the artist</param>
        /// <returns></returns>
        Task<HttpResponse<Artist>> GetArtist(TextFormat textFormat, string artistId);

        /// <summary>
        ///     Retrieves songs for the artist specified. By default, 20 items are returned for each request.
        /// </summary>
        /// <param name="textFormat">Format for text bodies related to the document</param>
        /// <param name="artistId">ID of the artist</param>
        /// <param name="sort">title(default) or popularity</param>
        /// <param name="perPage">Number of results to return per request</param>
        /// <param name="page">
        ///     Paginated offset (e.g., <![CDATA[per_page=5&page=3]]> returns songs 11-15)
        /// </param>
        /// <returns></returns>
        Task<HttpResponse<List<Song>>> GetSongsByArtist(TextFormat textFormat, string artistId,
            string sort = "", string perPage = "", string page = "");
    }
}