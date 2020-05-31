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
        ///     Creates a new instance of GeniusClient
        /// </summary>
        /// <param name="accessToken">Access Token to make authorized requests.</param>
        public GeniusClient(string accessToken)
        {
            IApiConnection apiConnection = new ApiConnection(accessToken);

            AccountsClient = new AccountsClient(apiConnection);
            AlbumsClient = new AlbumsClient(apiConnection);
            AnnotationsClient = new AnnotationsClient(apiConnection);
            ArtistsClient = new ArtistsClient(apiConnection);
            VoteClient = new VoteClient(apiConnection);
            ReferentsClient = new ReferentsClient(apiConnection);
            SongsClient = new SongsClient(apiConnection);
            SearchClient = new SearchClient(apiConnection);
            WebPagesClient = new WebPagesClient(apiConnection);
        }

        #region Clients

        /// <summary>
        /// </summary>
        public readonly IAccountsClient AccountsClient;

        /// <summary>
        /// </summary>
        public readonly IAlbumsClient AlbumsClient;

        /// <summary>
        ///     Clients for operations on Annotations.
        /// </summary>
        public readonly IAnnotationsClient AnnotationsClient;

        /// <summary>
        ///     Clients for operations related to Genius Artists.
        /// </summary>
        public readonly IArtistsClient ArtistsClient;

        /// <summary>
        ///     Clients for Referents related operations.
        /// </summary>
        public readonly IReferentsClient ReferentsClient;

        /// <summary>
        ///     Client for Searching Genius Database.
        /// </summary>
        public readonly ISearchClient SearchClient;

        /// <summary>
        ///     Client for operations related to Genius Songs.
        /// </summary>
        public readonly ISongsClient SongsClient;

        /// <summary>
        ///     Performs voting related operations like up-voting, down-voting and un-voting.
        /// </summary>
        public readonly IVoteClient VoteClient;

        /// <summary>
        ///     Clients for operations on Genius WebPages.
        /// </summary>
        public readonly IWebPagesClient WebPagesClient;

        #endregion
    }
}