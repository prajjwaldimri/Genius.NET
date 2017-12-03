using System.Threading.Tasks;
using Genius.Http;
using Genius.Models;

namespace Genius.Clients
{
    /// <inheritdoc />
    public class SongsClient : ISongsClient
    {
        private readonly IApiConnection _apiConnection;

        public SongsClient(IApiConnection apiConnection)
        {
            _apiConnection = apiConnection;
        }

        public async Task<HttpResponse<Song>> GetSong(TextFormat textFormat, string songId)
        {
            return await _apiConnection.Get<Song>(textFormat, songId);
        }
    }
}