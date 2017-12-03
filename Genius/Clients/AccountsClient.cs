using System;
using System.Threading.Tasks;
using Genius.Http;
using Genius.Models;

namespace Genius.Clients
{
    /// <inheritdoc />
    public class AccountsClient : IAccountsClient
    {
        private readonly IApiConnection _apiConnection;

        /// <summary>
        ///     Default Constructor
        /// </summary>
        /// <param name="apiConnection">Provide an apiConnection</param>
        public AccountsClient(IApiConnection apiConnection)
        {
            _apiConnection = apiConnection;
        }


        /// <inheritdoc />
        public async Task<HttpResponse<User>> GetAccountInfo(TextFormat textFormat)
        {
            var uri = new Uri("https://api.genius.com/account");
            return await _apiConnection.Get<User>(textFormat, uri: uri);
        }
    }
}