using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Genius.Core;
using Genius.Models;
using Genius.Models.Response;
using Jil;

namespace Genius
{
  public class GeniusClient : IGeniusClient
  {
    public GeniusClient(string apiKey)
    {
      ApiKey = apiKey;
    }

    /// <summary>
    /// See: http://genius.com/api-clients
    /// </summary>
    public string ApiKey { get; }

    public async Task Test()
    {
      try
      {
        var client = new HttpClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",
          ApiKey);


        var content = await client.GetStringAsync("https://api.genius.com/annotations/10225840");

        using (var input = new StringReader(content))
        {
          var result = JSON.Deserialize<AnnotationResponse>(input);
          Console.WriteLine(result);
        }
      }
      catch (Exception error)
      {
        Console.WriteLine(error);
      }
    }
  }
}