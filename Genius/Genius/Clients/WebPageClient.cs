using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Genius.Clients.Interfaces;
using Genius.Http;
using Genius.Models.Response;
using Jil;

namespace Genius.Clients
{
  public class WebPageClient : IWebPageClient
  {
    private static IGeniusRestClient _geniusRestClient;

    public WebPageClient(IGeniusRestClient geniusRestClient)
    {
      _geniusRestClient = geniusRestClient;
    }
    
    public async Task<WebPageResponse> GetWebPage(string rawAnnotatableUrl, string canonicalUrl = null,
      string ogUrl = null)
    {
      var endpoint = "/web_pages/lookup?raw_annotatable_url=" + rawAnnotatableUrl;

      if (!string.IsNullOrWhiteSpace(canonicalUrl))
      {
        endpoint += "&canonical_url=" + canonicalUrl;
      }

      if (!string.IsNullOrWhiteSpace(ogUrl))
      {
        endpoint += "&og_url=" + ogUrl;
      }

      var response = await _geniusRestClient.GetASync(endpoint);

      using (var input = new StringReader(response))
      {
        var webPageResponse = JSON.Deserialize<WebPageResponse>(input);
        if (webPageResponse.Meta.Status >= 400)
        {
          throw new HttpRequestException(webPageResponse.Meta.Status +
                                         webPageResponse.Meta.Message);
        }

        return webPageResponse;
      }
    }
  }
}