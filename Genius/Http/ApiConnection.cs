using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Genius.Helpers;
using Genius.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Genius.Http
{
    internal class ApiConnection : IApiConnection
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


        public async Task<HttpResponse<Annotation>> Vote(TextFormat textFormat, VoteType voteType, string annotationId)
        {
            using (var client = new HttpClient())
            {
                var baseAddress =
                    UriHelper.CreateUri<Annotation>(textFormat.ToString().ToLower(), annotationId, true, voteType);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", _accessToken);
                var response = await client.PutAsync(baseAddress, null).ConfigureAwait(false);
                using (var content = response.Content)
                {
                    var result = await content.ReadAsStringAsync().ConfigureAwait(false);
                    var jToken = JToken.Parse(result);
                    var jsonResponse = jToken.SelectToken("response").SelectToken("annotation");
                    var jsonMeta = jToken.SelectToken("meta");
                    return
                        new HttpResponse<Annotation>
                        {
                            Meta = jsonMeta.ToObject<Meta>(),
                            Response = jsonResponse.ToObject<Annotation>()
                        };
                }
            }
        }


        public async Task<HttpResponse<T>> Put<T>(TextFormat textFormat, string id, object payload, Uri uri = null)
        {
            using (var client = new HttpClient())
            {
                var baseAddress = uri ?? UriHelper.CreateUri<T>(textFormat.ToString().ToLower(), id);

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", _accessToken);

                var response = await client.PutAsync(baseAddress,
                    new StringContent(
                        JsonConvert.SerializeObject(payload, Formatting.None,
                            new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore}), Encoding.UTF8,
                        "application/json")).ConfigureAwait(false);

                using (var content = response.Content)
                {
                    var result = await content.ReadAsStringAsync().ConfigureAwait(false);
                    var jToken = JToken.Parse(result);
                    var jsonResponse = jToken.SelectToken("response").SelectToken(typeof(T).Name.ToLower());
                    var jsonMeta = jToken.SelectToken("meta");
                    return
                        new HttpResponse<T>
                        {
                            Meta = jsonMeta.ToObject<Meta>(),
                            Response = jsonResponse.ToObject<T>()
                        };
                }
            }
        }


        public async Task<HttpResponse<T>> Delete<T>(TextFormat textFormat, string id, Uri uri = null)
        {
            using (var client = new HttpClient())
            {
                var baseAddress = uri ?? UriHelper.CreateUri<T>(textFormat.ToString().ToLower(), id);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);

                var response = await client.DeleteAsync(baseAddress).ConfigureAwait(false);
                using (var content = response.Content)
                {
                    var result = await content.ReadAsStringAsync().ConfigureAwait(false);
                    var jToken = JToken.Parse(result);
                    var jsonResponse = jToken.SelectToken("response").SelectToken(typeof(T).Name.ToLower());
                    var jsonMeta = jToken.SelectToken("meta");
                    return
                        new HttpResponse<T>
                        {
                            Meta = jsonMeta.ToObject<Meta>(),
                            Response = jsonResponse.ToObject<T>()
                        };
                }
            }
        }


        public async Task<HttpResponse<T>> Post<T>(TextFormat textFormat, object payload, Uri uri = null)
        {
            using (var client = new HttpClient())
            {
                var baseAddress = uri ?? UriHelper.CreateUri<T>(textFormat.ToString().ToLower());

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", _accessToken);
                var response = await client.PostAsync(baseAddress,
                    new StringContent(
                        JsonConvert.SerializeObject(payload, Formatting.None,
                            new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore}),
                        Encoding.UTF8,
                        "application/json")).ConfigureAwait(false);

                using (var content = response.Content)
                {
                    var result = await content.ReadAsStringAsync().ConfigureAwait(false);
                    var jToken = JToken.Parse(result);
                    var jsonResponse = jToken.SelectToken("response").SelectToken(typeof(T).Name.ToLower());
                    var jsonMeta = jToken.SelectToken("meta");

                    return
                        new HttpResponse<T>
                        {
                            Meta = jsonMeta.ToObject<Meta>(),
                            Response = jsonResponse.ToObject<T>()
                        };
                }
            }
        }


        public async Task<HttpResponse<T>> Get<T>(TextFormat textFormat, string id = "", Uri uri = null,
            string jsonArrayName = "")
        {
            using (var client = new HttpClient())
            {
                var baseAddress = uri ?? UriHelper.CreateUri<T>(textFormat.ToString().ToLower(), id);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", _accessToken);
                var response = await client.GetAsync(baseAddress).ConfigureAwait(false);
                using (var content = response.Content)
                {
                    var result = await content.ReadAsStringAsync().ConfigureAwait(false);
                    var jToken = JToken.Parse(result);
                    var jsonResponse = jToken.SelectToken("response").SelectToken(
                        string.IsNullOrWhiteSpace(jsonArrayName)
                            ? typeof(T).Name.ToLower()
                            : jsonArrayName);
                    var jsonMeta = jToken.SelectToken("meta");
                    return
                        new HttpResponse<T>
                        {
                            Meta = jsonMeta.ToObject<Meta>(),
                            Response = jsonResponse.ToObject<T>()
                        };
                }
            }
        }
    }
}