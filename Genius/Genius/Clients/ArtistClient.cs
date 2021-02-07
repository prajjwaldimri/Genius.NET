using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Genius.Clients.Interfaces;
using Genius.Http;
using Genius.Models.Response;
using Jil;

namespace Genius.Clients
{
    public class ArtistClient : IArtistClient
    {
        private static IGeniusRestClient _geniusRestClient;

        public ArtistClient(IGeniusRestClient geniusRestClient)
        {
            _geniusRestClient = geniusRestClient;
        }

        public async Task<ArtistResponse> GetArtist(ulong artistId)
        {
            var response = await _geniusRestClient.GetASync("/artists/" + artistId + "?text_format=html");

            using (var input = new StringReader(response))
            {
                var artistResponse = JSON.Deserialize<ArtistResponse>(input);
                if (artistResponse.Meta.Status >= 400)
                {
                    throw new HttpRequestException(artistResponse.Meta.Status +
                                                   artistResponse.Meta.Message);
                }

                return artistResponse;
            }
        }

        public async Task<ArtistsSongsResponse> GetArtistsSongs(ulong artistId, string sort = "default",
          string perPage = null, string page = null)
        {
            var endpoint = "/artists/" + artistId + "/songs?" + "sort=" + sort;

            if (!string.IsNullOrWhiteSpace(perPage))
            {
                endpoint += "&per_page=" + perPage;
            }

            if (!string.IsNullOrWhiteSpace(page))
            {
                endpoint += "&page=" + page;
            }

            var response = await _geniusRestClient.GetASync(endpoint);

            using (var input = new StringReader(response))
            {
                var artistsSongsResponse = JSON.Deserialize<ArtistsSongsResponse>(input);
                if (artistsSongsResponse.Meta.Status >= 400)
                {
                    throw new HttpRequestException(artistsSongsResponse.Meta.Status +
                                                   artistsSongsResponse.Meta.Message);
                }

                return artistsSongsResponse;
            }
        }
    }
}