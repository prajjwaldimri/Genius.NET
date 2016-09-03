using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Genius
{
    public class ContentRetriever
    {
        public static string AuthorizationToken { get; set; }
        public static async void GetAnnotation(double id)
        {
            using (var client = new HttpClient())
            {
                var baseAddress = new Uri($"https://api.genius.com/annotations/{id}");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthorizationToken);
                var response = await client.GetAsync(baseAddress);
                using (var content = response.Content)
                {
                    var result = await content.ReadAsStringAsync();
                    var jToken = JToken.Parse(result);
                    var annotation = jToken.SelectToken("response").SelectToken("annotation");
                    var realannotation = JsonConvert.DeserializeObject<Annotation>(annotation.ToString());
                }
            }
        }
    }


}
