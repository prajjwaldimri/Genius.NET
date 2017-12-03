using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Genius.Helpers;
using Genius.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Genius.Http
{
    /// <summary>
    ///     A connection for making HTTP requests against URI Endpoints.
    ///     Provides type-friendly Http methods.
    /// </summary>
    internal class ApiConnection
    {
        private readonly string _accessToken;

        /// <summary>
        ///     Recommended: Initialize ApiConnection using an accessToken
        /// </summary>
        /// <param name="accessToken">https://docs.genius.com/#/authentication-h1</param>
        public ApiConnection(string accessToken)
        {
            _accessToken = accessToken;
        }

        public async Task<HttpResponse<T>> Get<T>(string textFormat, string id = "")
        {
            using (var client = new HttpClient())
            {
                var baseAddress =
                    UriHelper.CreateUri<T>(textFormat, id);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", _accessToken);
                var response = await client.GetAsync(baseAddress).ConfigureAwait(false);
                using (var content = response.Content)
                {
                    var result = await content.ReadAsStringAsync().ConfigureAwait(false);
                    var jToken = JToken.Parse(result);
                    var jsonResponse = jToken.SelectToken("response").SelectToken(typeof(T).Name.ToLower());
                    var jsonMeta = jToken.SelectToken("meta");
                    return
                        new HttpResponse<T>
                        {
                            Meta = JsonConvert.DeserializeObject<Meta>(jsonMeta.ToString()),
                            Response = JsonConvert.DeserializeObject<T>(jsonResponse.ToString())
                        };
                }
            }
        }
    }
}