using Jil;
// ReSharper disable ClassNeverInstantiated.Global

namespace Genius.Models
{
  /// <summary>
  /// Account information includes general contact information and Genius-specific details about a user.
  /// See: https://docs.genius.com/#/account-h2
  /// </summary>
  public class Account
  {
    [JilDirective(Name = "meta")] public Meta Meta { get; set; }

    [JilDirective(Name = "response")] public AccountResponse Response { get; set; }
  }

  public class AccountResponse
  {
    [JilDirective(Name = "user")] public User.User User { get; set; }
  }
}