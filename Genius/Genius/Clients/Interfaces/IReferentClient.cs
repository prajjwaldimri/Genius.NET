using System.Threading.Tasks;
using Genius.Models.Response;

namespace Genius.Clients.Interfaces
{
  /// <summary>
  /// Handles referent related queries.
  /// See: https://docs.genius.com/#referents-h2
  /// </summary>
  public interface IReferentClient
  {
    /// <summary>
    /// Referents by content item or user responsible for an included annotation.
    /// You may pass only one of song_id and web_page_id, not both.
    /// </summary>
    /// <param name="createdById">ID of a user to get referents for</param>
    /// <param name="songId">ID of a song to get referents for</param>
    /// <param name="webPageId">ID of a web page to get referents for</param>
    /// <param name="perPage">Number of results to return per request</param>
    /// <param name="page">Paginated offset, (e.g., per_page=5&amp;page=3 returns songs 11–15)</param>
    /// <returns></returns>
    Task<ReferentResponse> GetReferent(string createdById = null, string songId = null,
      string webPageId = null, string perPage = null, string page = null);
  }
}