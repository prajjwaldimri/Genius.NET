using System.Collections.Generic;
using System.Threading.Tasks;
using Genius.Helpers;
using Genius.Http;
using Genius.Models;

namespace Genius.Clients
{
    /// <inheritdoc />
    public class ArtistsClient : IArtistsClient
    {
        private readonly IApiConnection _apiConnection;

        public ArtistsClient(IApiConnection apiConnection)
        {
            _apiConnection = apiConnection;
        }

        public async Task<HttpResponse<Artist>> GetArtist(TextFormat textFormat, string artistId)
        {
            return await _apiConnection.Get<Artist>(textFormat, artistId);
        }

        public async Task<HttpResponse<List<Song>>> GetSongsByArtist(TextFormat textFormat, string artistId,
            string sort = "", string perPage = "", string page = "")
        {
            var uri = UriHelper.CreateUri<Artist>(textFormat.ToString().ToLower(), artistId, sort: sort,
                perPage: perPage, page: page, additionalUrl: "/songs");
            return await _apiConnection.Get<List<Song>>(textFormat, uri: uri, jsonArrayName: "songs");
        }
    }
}