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
        /// <summary>
        /// Returns object containing Annotation and Referent returned by "GET /annotations/:id"
        /// Annotation data returned from the API includes both the substance of the annotation and the necessary
        /// information for displaying it in its original context.
        /// For more info see https://docs.genius.com/#annotations-h2
        /// </summary>
        /// <param name="id">Id for the Annotation</param>
        /// <returns></returns>
        public static async Task<GetAnnotationResult> GetAnnotationbyId(string id)
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
                var baseAddress = new Uri($"https://api.genius.com/referents?song_id={songId}&created_by_id={createdById}");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthorizationToken);
                var response = await client.GetAsync(baseAddress);
                using (var content = response.Content)
                {
                    var result = await content.ReadAsStringAsync();
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
                var baseAddress = new Uri($"https://api.genius.com/referents?created_by_id={createdById}&web_page_id={webPageId}");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthorizationToken);
                var response = await client.GetAsync(baseAddress);
                using (var content = response.Content)
                {
                    var result = await content.ReadAsStringAsync();
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
        /// <param name="id">Id of the song</param>
        /// <returns>A Song Object</returns>
        public static async Task<Song> GetSongbyId(string id)
        {
            using (var client = new HttpClient())
            {
                var baseAddress = new Uri($"https://api.genius.com/songs/{id}");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthorizationToken);
                var response = await client.GetAsync(baseAddress);
                using (var content = response.Content)
                {
                    var result = await content.ReadAsStringAsync();
                    var jToken = JToken.Parse(result);
                    var jsonSong = jToken.SelectToken("response").SelectToken("song");
                    var songObject = JsonConvert.DeserializeObject<Song>(jsonSong.ToString());
                    return songObject;
                }
            }
        }

        /// <summary>
        /// Gets Data for a specific artist using his/her Genius Id
        /// </summary>
        /// <param name="id">ID of the artist</param>
        /// <returns>An Artist Object</returns>
        public static async Task<Artist> GetArtistById(string id)
        {
            using (var client = new HttpClient())
            {
                var baseAddress = new Uri($"https://api.genius.com/artists/{id}");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthorizationToken);
                var response = await client.GetAsync(baseAddress);
                using (var content = response.Content)
                {
                    var result = await content.ReadAsStringAsync();
                    var jToken = JToken.Parse(result);
                    var jsonArtist = jToken.SelectToken("response").SelectToken("artist");
                    var artistObject = JsonConvert.DeserializeObject<Artist>(jsonArtist.ToString());
                    return artistObject;
                }
            }
        }
    }

    /// <summary>
    /// Stores result returned from GetAnnotation Method in the form of Annotation and Referent Classes
    /// </summary>
    public class GetAnnotationResult
    {
        public Annotation Annotation { get; set; }
        public Referent Referent { get; set; }
    }
}
