using System.Threading.Tasks;
using Genius.Models;

namespace Genius.Clients
{
    /// <summary>
    ///     https://docs.genius.com/#!#account-h2
    /// </summary>
    public interface IAccountClient
    {
        Task<User> GetAccountInfo();
    }
}