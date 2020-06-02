using Jil;

// ReSharper disable ClassNeverInstantiated.Global

namespace Genius.Models.Response
{
  /// <summary>
  /// Account information includes general contact information and Genius-specific details about a user.
  /// See: https://docs.genius.com/#/account-h2
  /// </summary>
  public class AccountResponse
  {
    [JilDirective(Name = "meta")] public Meta Meta { get; set; }

    [JilDirective(Name = "response")] public AccountData Response { get; set; }
  }

  public class AccountData
  {
    [JilDirective(Name = "user")] public User.User User { get; set; }
  }
}