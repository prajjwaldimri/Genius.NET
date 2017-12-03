using System;
using System.Threading.Tasks;
using Genius.Http;
using Genius.Models;

namespace Genius.Clients
{
    /// <inheritdoc />
    /// <summary>
    ///     Gets information about genius user currently authenticated
    /// </summary>
    public class AccountsClient : IAccountsClient
    {
        private readonly IApiConnection _apiConnection;

        public AccountsClient(IApiConnection apiConnection)
        {
            _apiConnection = apiConnection;
        }


        public async Task<HttpResponse<User>> GetAccountInfo(TextFormat textFormat)
        {
            var uri = new Uri("https://api.genius.com/account");
            return await _apiConnection.Get<User>(textFormat, uri: uri);
        }
    }
}