using System.Threading.Tasks;
using Genius.Models.Response;

namespace Genius.Clients.Interfaces
{
  /// <summary>
  /// Handles Artist Related Queries
  /// See: https://docs.genius.com/#artists-h2
  /// </summary>
  public interface IArtistClient
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="artistId"></param>
    /// <returns>Details about an artist</returns>
    Task<ArtistResponse> GetArtist(ulong artistId);

    /// <summary>
    /// Documents (songs) for the artist specified. By default, 20 items are returned for each request.
    /// </summary>
    /// <param name="artistId">ID of the artist. </param>
    /// <param name="sort">title (default) or popularity</param>
    /// <param name="perPage">Number of results to return per request</param>
    /// <param name="page">Paginated offset, (e.g., per_page=5&amp;page=3 returns songs 11–15)</param>
    /// <returns>Multiple songs of an artist</returns>
    Task<ArtistsSongsResponse> GetArtistsSongs(ulong artistId, string sort = "default", string perPage = null,
      string page = null);
  }
}