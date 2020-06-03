using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Genius.Http
{
  public sealed class GeniusRestClient : IGeniusRestClient
  {
    /// <summary>
    /// Singleton to solve the thread exhaustion problem.
    /// Note: Can't use IHttpClientFactory as it doesn't support .Net Standard 1.6
    /// </summary>
    private static readonly HttpClient Client = new HttpClient {BaseAddress = new Uri("https://api.genius.com")};

    private static string _apiKey;

    private static readonly GeniusRestClient _instance = new GeniusRestClient();

    public static GeniusRestClient Instance => _instance;

    private GeniusRestClient()
    {
    }

    public async Task<string> PostASync(string endpoint, string serializedPayload)
    {
      if (string.IsNullOrWhiteSpace(_apiKey))
      {
        throw new NullReferenceException("Please use SetApiKey method before" +
                                         " calling any other methods");
      }

      var response = await Client.PostAsync(endpoint,
        new StringContent(serializedPayload, Encoding.UTF8, "application/json"));

      return await response.Content.ReadAsStringAsync();
    }

    public async Task<string> PutASync(string endpoint, string serializedPayload = null)
    {
      if (string.IsNullOrWhiteSpace(_apiKey))
      {
        throw new NullReferenceException("Please use SetApiKey method before" +
                                         " calling any other methods");
      }

      HttpResponseMessage response;

      if (string.IsNullOrWhiteSpace(serializedPayload))
      {
        response = await Client.PutAsync(endpoint, null);
      }
      else
      {
        response = await Client.PutAsync(endpoint,
          new StringContent(serializedPayload, Encoding.UTF8, "application/json"));
      }

      return await response.Content.ReadAsStringAsync();
    }

    public async Task<string> DeleteASync(string endpoint)
    {
      if (string.IsNullOrWhiteSpace(_apiKey))
      {
        throw new NullReferenceException("Please use SetApiKey method before" +
                                         " calling any other methods");
      }

      var response = await Client.DeleteAsync(endpoint);
      return await response.Content.ReadAsStringAsync();
    }

    public void SetApiKey(string apiKey)
    {
      _apiKey = apiKey;
      Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",
        _apiKey);
    }

    public async Task<string> GetASync(string endpoint)
    {
      if (string.IsNullOrWhiteSpace(_apiKey))
      {
        throw new NullReferenceException("Please use SetApiKey method before" +
                                         " calling any other methods");
      }

      return await Client.GetStringAsync(endpoint);
    }
  }
}