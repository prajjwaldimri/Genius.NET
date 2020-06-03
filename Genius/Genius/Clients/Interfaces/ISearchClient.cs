using System.Threading.Tasks;
using Genius.Models.Response;

namespace Genius.Clients.Interfaces
{
  /// <summary>
  /// Handles search
  /// </summary>
  public interface ISearchClient
  {
    /// <summary>
    /// Search documents hosted on Genius.
    /// </summary>
    /// <param name="query">The term to search for</param>
    /// <returns>Hits based on your search query</returns>
    Task<SearchResponse> Search(string query);
  }
}