using System.Threading.Tasks;

namespace Genius.Http
{
    /// <summary>
    /// Also see: https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests
    /// </summary>
    public interface IGeniusRestClient
  {
    /// <summary>
    /// Sends GET request to endpoint.
    /// </summary>
    /// <param name="endpoint">Base address is already set. No need to include api.genius.com in endpoint</param>
    /// <returns>JSON content as string.</returns>
    Task<string> GetASync(string endpoint);

    /// <summary>
    /// Sends POST request to endpoint with data
    /// </summary>
    /// <param name="endpoint"></param>
    /// <param name="serializedPayload"></param>
    /// <returns></returns>
    Task<string> PostASync(string endpoint, string serializedPayload);

    /// <summary>
    /// Sends PUT request to endpoint with optional data
    /// </summary>
    /// <param name="endpoint"></param>
    /// <param name="serializedPayload"></param>
    /// <returns></returns>
    Task<string> PutASync(string endpoint, string serializedPayload = null);

    /// <summary>
    /// Sends DELETE request to endpoint
    /// </summary>
    /// <param name="endpoint"></param>
    /// <returns></returns>
    Task<string> DeleteASync(string endpoint);

    /// <summary>
    /// Sets API Key as the authentication header in HttpClient.
    /// Required to call.
    /// </summary>
    /// <param name="apiKey"></param>
    void SetApiKey(string apiKey);
  }
}