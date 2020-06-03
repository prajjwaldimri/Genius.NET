using System.IO;
using System.Threading.Tasks;
using Genius.Clients.Interfaces;
using Genius.Http;
using Genius.Models.Response;
using Jil;

namespace Genius.Clients
{
  public class AccountClient : IAccountClient
  {
    private static IGeniusRestClient _geniusRestClient;

    public AccountClient(IGeniusRestClient geniusRestClient)
    {
      _geniusRestClient = geniusRestClient;
    }

    public async Task<AccountResponse> GetAccount()
    {
      var response = await _geniusRestClient.GetASync("/account");

      using (var input = new StringReader(response))
      {
        return JSON.Deserialize<AccountResponse>(input);
      }
    }
  }
}