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
	/// Used for retrieving actual content.
	/// </summary>
    public class ContentRetriever
    {
	    /// <summary>
	    /// The token that is used for authorization.
	    /// </summary>
		public static string AuthorizationToken { get; set; }

        /// <summary>
        /// Returns object containing Annotation and Referent returned by "GET /annotations/:artistId"
        /// Annotation data returned from the API includes both the substance of the annotation and the necessary
        /// information for displaying it in its original context.
        /// For more info see https://docs.genius.com/#annotations-h2
        /// </summary>
        /// <param name="annotationId">Id for the Annotation</param>
        /// <returns></returns>
        public static async Task<GetAnnotationResult> GetAnnotationbyId(string annotationId)
        {
            using (var client = new HttpClient())
            {
                const string textFormat = "dom";
                var baseAddress = new Uri($"https://api.genius.com/annotations/{annotationId}?text_format={textFormat}");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthorizationToken);
                var response = await client.GetAsync(baseAddress).ConfigureAwait(false);
                using (var content = response.Content)
                {
                    var result = await content.ReadAsStringAsync().ConfigureAwait(false);
                    var jToken = JToken.Parse(result);
                    var jsonAnnotation = jToken.SelectToken("response").SelectToken("annotation");
                    var jsonReferent = jToken.SelectToken("response").SelectToken("referent");
                    var annotationObject = JsonConvert.DeserializeObject<Annotation>(jsonAnnotation.ToString());
                    var referentObject = JsonConvert.DeserializeObject<Referent>(jsonReferent.ToString());
                    return new GetAnnotationResult { Annotation = annotationObject, Referent = referentObject };
                }
            }
        }

        //TODO: Add Per-page and paginated offset
        /// <summary>
        /// Gets Referents using SongId Or UserId
        /// You may pass only one of song_id and web_page_id, not both.
        /// </summary>
        /// <param name="songId">ID of a song to get referents for</param>
        /// <param name="createdById">ID of a user to get referents for</param>
        /// <returns>A List of Referents</returns>
        public static async Task<List<Referent>> GetReferentsbySongId(string songId, string createdById = "")
        {
            using (var client = new HttpClient())
            {
                const string textFormat = "dom";
                var baseAddress = new Uri($"https://api.genius.com/referents?text_format={textFormat}&song_id={songId}&created_by_id={createdById}");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthorizationToken);
                var response = await client.GetAsync(baseAddress).ConfigureAwait(false);
                using (var content = response.Content)
                {
                    var result = await content.ReadAsStringAsync().ConfigureAwait(false);
                    var jToken = JToken.Parse(result);
                    var jsonReferents = jToken.SelectToken("response").SelectToken("referents");
                    var referentObject = JsonConvert.DeserializeObject<List<Referent>>(jsonReferents.ToString());
                    return referentObject;
                }
            }
        }

        /// <summary>
        /// Gets Referents using WebPageId or UserId
        /// You may pass only one of song_id and web_page_id, not both.
        /// </summary>
        /// <param name="webPageId">ID of a web page to get referents for</param>
        /// <param name="createdById">ID of a user to get referents for</param>
        /// <returns>A List of Referents</returns>
        public static async Task<List<Referent>> GetReferentsbyWebPageId(string webPageId, string createdById = "")
        {
            using (var client = new HttpClient())
            {
                const string textFormat = "dom";
                var baseAddress = new Uri($"https://api.genius.com/referents?text_format={textFormat}&created_by_id={createdById}&web_page_id={webPageId}");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthorizationToken);
                var response = await client.GetAsync(baseAddress).ConfigureAwait(false);
                using (var content = response.Content)
                {
                    var result = await content.ReadAsStringAsync().ConfigureAwait(false);
                    var jToken = JToken.Parse(result);
                    var jsonReferents = jToken.SelectToken("response").SelectToken("referents");
                    var referentObject = JsonConvert.DeserializeObject<List<Referent>>(jsonReferents.ToString());
                    return referentObject;
                }
            }
        }

        /// <summary>
        /// Gets Data for a specific Song
        /// </summary>
        /// <param name="songId">Id of the song</param>
        /// <returns>A Song Object</returns>
        public static async Task<Song> GetSongbyId(string songId)
        {
            using (var client = new HttpClient())
            {
                const string textFormat = "dom";
                var baseAddress = new Uri($"https://api.genius.com/songs/{songId}?text_format={textFormat}");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthorizationToken);
                var response = await client.GetAsync(baseAddress).ConfigureAwait(false);
                using (var content = response.Content)
                {
                    var result = await content.ReadAsStringAsync().ConfigureAwait(false);
                    var jToken = JToken.Parse(result);
                    var jsonSong = jToken.SelectToken("response").SelectToken("song");
                    var songObject = JsonConvert.DeserializeObject<Song>(jsonSong.ToString());
                    return songObject;
                }
            }
        }

        /// <summary>
        /// Data for a specific artist.
        /// </summary>
        /// <param name="artistId">ID of the artist </param>
        /// <returns>An Artist Object</returns>
        public static async Task<Artist> GetArtistById(string artistId)
        {
            using (var client = new HttpClient())
            {
                const string textFormat = "dom";
                var baseAddress = new Uri($"https://api.genius.com/artists/{artistId}?text_format={textFormat}");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthorizationToken);
                var response = await client.GetAsync(baseAddress).ConfigureAwait(false);
                using (var content = response.Content)
                {
                    var result = await content.ReadAsStringAsync().ConfigureAwait(false);
                    var jToken = JToken.Parse(result);
                    var jsonArtist = jToken.SelectToken("response").SelectToken("artist");
                    var artistObject = JsonConvert.DeserializeObject<Artist>(jsonArtist.ToString());
                    return artistObject;
                }
            }
        }

        /// <summary>
        /// Documents (songs) for the artist specified. By default, 20 items are returned for each request.
        /// </summary>
        /// <param name="artistId">ID of the artist. </param>
        /// <param name="sort">	title (default) or popularity</param>
        /// <param name="perPage">Number of results to return per request</param>
        /// <param name="paginatedOffset">Paginated offset, (e.g., per_page=5&amp;page=3 returns songs 11–15)</param>
        /// <returns>List of Songs</returns>
        public static async Task<List<Song>> GetSongsbyArtist(string artistId, string sort = "title", string perPage = "", string paginatedOffset = "")
        {
            using (var client = new HttpClient())
            {
                var baseAddress = new Uri($"https://api.genius.com/artists/{artistId}/songs");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthorizationToken);
                var response = await client.GetAsync(baseAddress).ConfigureAwait(false);
                using (var content = response.Content)
                {
                    var result = await content.ReadAsStringAsync().ConfigureAwait(false);
                    var jToken = JToken.Parse(result);
                    var jsonSongs = jToken.SelectToken("response").SelectToken("songs");
                    var songsObject = JsonConvert.DeserializeObject<List<Song>>(jsonSongs.ToString());
                    return songsObject;
                }
            }
        }

        public static async Task<WebPage> GetWebPagebyUrl(string rawAnnotableUrl, string canonicalUrl = "", string ogUrl = "")
        {
            using (var client = new HttpClient())
            {
                var baseAddress = new Uri($"https://api.genius.com/web_pages/lookup?raw_annotatable_url={rawAnnotableUrl}&canoncial_url={canonicalUrl}&og_url={ogUrl}");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthorizationToken);
                var response = await client.GetAsync(baseAddress).ConfigureAwait(false);
                using (var content = response.Content)
                {
                    var result = await content.ReadAsStringAsync().ConfigureAwait(false);
                    var jToken = JToken.Parse(result);
                    var jsonWebPage = jToken.SelectToken("response").SelectToken("web_page");
                    var webPageObject = JsonConvert.DeserializeObject<WebPage>(jsonWebPage.ToString());
                    return webPageObject;
                }
            }
        }

		/// <summary>
		/// Account info of the user, dependent on the given <see cref="AuthorizationToken"/>.
		/// </summary>
		/// <returns>The user document (see <see cref="User"/>).</returns>
        public static async Task<User> GetAccountInfo()
        {
            using (var client = new HttpClient())
            {
                const string textFormat = "dom";
                var baseAddress = new Uri($"https://api.genius.com/account?text_format={textFormat}");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthorizationToken);
                var response = await client.GetAsync(baseAddress).ConfigureAwait(false);
                using (var content = response.Content)
                {
                    var result = await content.ReadAsStringAsync().ConfigureAwait(false);
                    var jToken = JToken.Parse(result);
                    var jsonUser = jToken.SelectToken("response").SelectToken("user");
                    var userObject = JsonConvert.DeserializeObject<User>(jsonUser.ToString());
                    return userObject;
                }
            }
        }
    }

    /// <summary>
    /// Stores result returned from GetAnnotation Method in the form of Annotation and Referent Classes
    /// </summary>
    public class GetAnnotationResult
    {
		/// <summary>
		/// The annotation, <see cref="Annotation"/> for more information.
		/// </summary>
        public Annotation Annotation { get; set; }
		/// <summary>
		/// The referent, <see cref="Referent"/> for more information.
		/// </summary>
        public Referent Referent { get; set; }
    }
}
