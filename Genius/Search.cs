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
    public class Search
    {
        public static string AuthenticationToken { get; set; }
        public static string SearchTerm { get; set; }

        public static async Task<List<Hit>> DoSearch()
        {
            if (string.IsNullOrEmpty(SearchTerm)) throw new ArgumentNullException(SearchTerm);

            using (var client = new HttpClient())
            {
                var baseAddress = $"https://api.genius.com/search?q={SearchTerm}";
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthenticationToken);
                var response = await client.GetAsync(baseAddress);
                using (var content = response.Content)
                {
                    var result = await content.ReadAsStringAsync();
                    var jToken = JToken.Parse(result);
                    var jsonHits = jToken.SelectToken("response").SelectToken("hits");
                    var hitsObject = JsonConvert.DeserializeObject<List<Hit>>(jsonHits.ToString());
                    return hitsObject;
                }
            }
        }
    }

    public class Hit
    {
        public string Index { get; set; }
        public string type { get; set; }
        public Song Result { get; set; }
    }
}
