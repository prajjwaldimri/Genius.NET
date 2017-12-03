using Genius.Clients;
using Genius.Http;

namespace Genius
{
    /// <summary>
    ///     A client for Genius API
    /// </summary>
    public class GeniusClient
    {
        /// <summary>
        ///     https://docs.genius.com/#/authentication-h1
        /// </summary>
        private readonly string _accessToken;

        private readonly IApiConnection _apiConnection;

        public readonly IAccountClient AccountClient;
        public IAnnotationClient AnnotationClient;


        /// <summary>
        ///     Creates a new instance of GeniusClient
        /// </summary>
        /// <param name="accessToken">Access Token to make authorized requests.</param>
        public GeniusClient(string accessToken)
        {
            _accessToken = accessToken;
            _apiConnection = new ApiConnection(_accessToken);

            AccountClient = new AccountClient(_apiConnection);
            AnnotationClient = new AnnotationClient(_apiConnection);
        }
    }
}