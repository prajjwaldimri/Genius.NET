using System.Threading.Tasks;
using Genius.Http;
using Genius.Models;

namespace Genius.Clients
{
    /// <inheritdoc />
    public class VoteClient : IVoteClient
    {
        private readonly IApiConnection _apiConnection;

        /// <inheritdoc />
        public VoteClient(IApiConnection apiConnection)
        {
            _apiConnection = apiConnection;
        }

        /// <inheritdoc />
        public async Task<HttpResponse<Annotation>> Vote(VoteType voteType, string id, TextFormat textFormat)
        {
            return await _apiConnection.Vote(textFormat, voteType, id);
        }
    }
}