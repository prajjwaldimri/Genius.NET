using System.Threading.Tasks;
using Genius.Models.Response;

namespace Genius.Clients.Interfaces
{
  /// <summary>
  /// Handles user's account related queries
  /// See: https://docs.genius.com/#/account-h2
  /// </summary>
  public interface IAccountClient
  {
    /// <summary>
    /// Gets account information for the currently authenticated user.
    /// See: https://docs.genius.com/#/account-h2
    /// </summary>
    /// <returns>Account information for the currently authenticated user.</returns>
    Task<AccountResponse> GetAccount();
  }
}