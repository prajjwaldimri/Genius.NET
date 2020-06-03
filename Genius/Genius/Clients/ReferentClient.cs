using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Genius.Clients.Interfaces;
using Genius.Http;
using Genius.Models.Response;
using Jil;

namespace Genius.Clients
{
  public class ReferentClient : IReferentClient
  {
    private static IGeniusRestClient _geniusRestClient;

    public ReferentClient(IGeniusRestClient geniusRestClient)
    {
      _geniusRestClient = geniusRestClient;
    }

    public async Task<ReferentResponse> GetReferent(string createdById = null, string songId = null,
      string webPageId = null, string perPage = null, string page = null)
    {
      var urlParameters = "";
      if (!string.IsNullOrWhiteSpace(songId) && !string.IsNullOrWhiteSpace(webPageId))
      {
        throw new ArgumentException("You may pass only one of songId and webPageId, not both.");
      }

      if (string.IsNullOrWhiteSpace(songId))
      {
        urlParameters += "web_page_id=" + webPageId;
      }
      else
      {
        urlParameters += "song_id=" + songId;
      }

      if (!string.IsNullOrWhiteSpace(createdById))
      {
        urlParameters += "&created_by_id=" + createdById;
      }

      if (!string.IsNullOrWhiteSpace(perPage))
      {
        urlParameters += "&per_page=" + perPage;
      }

      if (!string.IsNullOrWhiteSpace(page))
      {
        urlParameters += "&page=" + page;
      }


      var response = await _geniusRestClient.GetASync("/referents?" + urlParameters);

      using (var input = new StringReader(response))
      {
        var annotationResponse = JSON.Deserialize<ReferentResponse>(input);
        if (annotationResponse.Meta.Status >= 400)
        {
          throw new HttpRequestException(annotationResponse.Meta.Status +
                                         annotationResponse.Meta.Message);
        }

        return annotationResponse;
      }
    }
  }
}