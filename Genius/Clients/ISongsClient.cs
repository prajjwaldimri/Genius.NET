using System.Threading.Tasks;
using Genius.Models;

namespace Genius.Clients
{
    /// <summary>
    ///     A song is a document hosted on Genius. It's usually music lyrics.
    ///     https://docs.genius.com/#songs-h2
    /// </summary>
    public interface ISongsClient
    {
        Task<HttpResponse<Song>> GetSong(TextFormat textFormat, string songId);
    }
}