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
            AccessToken = accessToken;
        }

        /// <summary>
        ///     https://docs.genius.com/#/authentication-h1
        /// </summary>
        public string AccessToken { get; set; }
    }
}