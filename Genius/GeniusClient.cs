using Genius.Clients;
using Genius.Http;

namespace Genius
{
    /// <summary>
    ///     A client for Genius API
    /// </summary>
    public class GeniusClient
    {
        public readonly IAccountClient AccountClient;
        public readonly IAnnotationClient AnnotationClient;
        public readonly IVoteClient VoteClient;


        /// <summary>
        ///     Creates a new instance of GeniusClient
        /// </summary>
        /// <param name="accessToken">Access Token to make authorized requests.</param>
        public GeniusClient(string accessToken)
        {
            IApiConnection apiConnection = new ApiConnection(accessToken);

            AccountClient = new AccountClient(apiConnection);
            AnnotationClient = new AnnotationClient(apiConnection);
            VoteClient = new VoteClient(apiConnection);
        }
    }
}