using System.Threading.Tasks;
using Genius.Models;

namespace Genius.Clients
{
    /// <summary>
    ///     https://docs.genius.com/#!#account-h2
    /// </summary>
    public interface IAccountsClient
    {
        Task<HttpResponse<User>> GetAccountInfo(TextFormat textFormat);
    }
}