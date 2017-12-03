using System.Threading.Tasks;
using Genius.Helpers;
using Genius.Http;
using Genius.Models;

namespace Genius.Clients
{
    /// <inheritdoc />
    public class ReferentsClient : IReferentsClient
    {
        private readonly IApiConnection _apiConnection;

        public ReferentsClient(IApiConnection apiConnection)
        {
            _apiConnection = apiConnection;
        }

        public async Task<HttpResponse<Referent>> GetReferentBySongId(TextFormat textFormat, string songId,
            string createdById = "", string perPage = "",
            string page = "")
        {
            var uri = UriHelper.CreateUri<Referent>(textFormat.ToString().ToLower(), songId: songId,
                createdById: createdById, perPage: perPage, page: page);
            return await _apiConnection.Get<Referent>(textFormat, uri: uri);
        }

        public async Task<HttpResponse<Referent>> GetReferentByWebPageId(TextFormat textFormat, string webPageId,
            string createdById = "", string perPage = "",
            string page = "")
        {
            var uri = UriHelper.CreateUri<Referent>(textFormat.ToString().ToLower(), webPageId: webPageId,
                createdById: createdById, perPage: perPage, page: page);
            return await _apiConnection.Get<Referent>(textFormat, uri: uri);
        }
    }
}