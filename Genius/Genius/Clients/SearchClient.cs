using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Genius.Clients.Interfaces;
using Genius.Http;
using Genius.Models.Response;
using Jil;

namespace Genius.Clients
{
  public class SearchClient : ISearchClient
  {
    private static IGeniusRestClient _geniusRestClient;

    public SearchClient(IGeniusRestClient geniusRestClient)
    {
      _geniusRestClient = geniusRestClient;
    }
    
    public async Task<SearchResponse> Search(string query)
    {
      var response = await _geniusRestClient.GetASync("/search?q=/" + query);

      using (var input = new StringReader(response))
      {
        var searchResponse = JSON.Deserialize<SearchResponse>(input);
        if (searchResponse.Meta.Status >= 400)
        {
          throw new HttpRequestException(searchResponse.Meta.Status +
                                         searchResponse.Meta.Message);
        }

        return searchResponse;
      }
    }
  }
}