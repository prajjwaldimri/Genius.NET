using System.Threading.Tasks;
using Genius.Models;

namespace Genius.Clients
{
    /// <summary>
    ///     Gets information about genius user currently authenticated
    ///     https://docs.genius.com/#!#account-h2
    /// </summary>
    public interface IAccountsClient
    {
        /// <summary>
        ///     Gets the account information of the currently authenticated user.
        /// </summary>
        /// <param name="textFormat">Format for text bodies related to the document</param>
        /// <returns>User Object containing all details of the authenticated User</returns>
        Task<HttpResponse<User>> GetAccountInfo(TextFormat textFormat);
    }
}