using System.Threading.Tasks;
using Genius.Models.Response;

namespace Genius.Clients.Interfaces
{
  /// <summary>
  /// Handles Song Related Queries
  /// See: https://docs.genius.com/#songs-h2
  /// </summary>
  public interface ISongClient
  {
    /// <summary>
    /// Gets data for a specific song.
    /// </summary>
    /// <param name="songId">ID of the song</param>
    Task<SongResponse> GetSong(ulong songId);
  }
}