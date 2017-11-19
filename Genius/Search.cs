using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Genius.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Genius
{
	/// <summary>
	/// Ability to perform a search.
	/// </summary>
    public class Search
    {
	    /// <summary>
	    /// The token that is used for authorization.
	    /// </summary>
		public static string AuthenticationToken { get; set; }

		/// <summary>
		/// Perform a search with the given <paramref name="searchTerm"/>.
		/// </summary>
		/// <param name="searchTerm">The term that will be used to search.</param>
		/// <returns>An async list of all hits (i.e. search results).</returns>
        public static async Task<List<Hit>> DoSearch(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm)) throw new ArgumentNullException(searchTerm);

            using (var client = new HttpClient())
            {
                var baseAddress = $"https://api.genius.com/search?q={searchTerm}";
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthenticationToken);
                var response = await client.GetAsync(baseAddress).ConfigureAwait(false);
                using (var content = response.Content)
                {
                    var result = await content.ReadAsStringAsync().ConfigureAwait(false);
                    var jToken = JToken.Parse(result);
                    var jsonHits = jToken.SelectToken("response").SelectToken("hits");
                    var hitsObject = JsonConvert.DeserializeObject<List<Hit>>(jsonHits.ToString());
                    return hitsObject;
                }
            }
        }
    }

	/// <summary>
	/// A response from the search.
	/// </summary>
    public class Hit
    {
		/// <summary>
		/// The index of this hit.
		/// </summary>
        public string Index { get; set; }
		/// <summary>
		/// The type of this hit (e.g. song, artist ...)
		/// </summary>
		public string Type { get; set; }
		/// <summary>
		/// The actual result. We only consider found songs.
		/// </summary>
        public Song Result { get; set; }
    }
}
