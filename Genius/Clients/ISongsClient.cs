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
        /// <summary>
        ///     Gets Data for a specific song.
        /// </summary>
        /// <param name="textFormat">Format for text bodies related to the document</param>
        /// <param name="songId">ID of the song</param>
        /// <returns></returns>
        Task<HttpResponse<Song>> GetSong(TextFormat textFormat, string songId);
    }
}