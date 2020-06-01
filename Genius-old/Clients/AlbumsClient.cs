using System.Threading.Tasks;
using Genius.Http;
using Genius.Models;

namespace Genius.Clients
{
    /// <inheritdoc />
    public class AlbumsClient : IAlbumsClient
    {
        private readonly IApiConnection _apiConnection;

        /// <inheritdoc />
        public AlbumsClient(IApiConnection apiConnection)
        {
            _apiConnection = apiConnection;
        }

        /// <inheritdoc />
        public async Task<HttpResponse<Album>> GetAlbum(TextFormat textFormat, string albumId)
        {
            return await _apiConnection.Get<Album>(textFormat, albumId);
        }
    }
}