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
        private IApiConnection _apiConnection;

        public AccountsClient(IApiConnection apiConnection)
        {
            _apiConnection = apiConnection;
        }

        public Task<User> GetAccountInfo()
        {
            throw new NotImplementedException();
        }
    }
}