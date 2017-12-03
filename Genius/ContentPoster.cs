using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Genius.Models;
using Newtonsoft.Json;

namespace Genius
{
    public class ContentPoster
    {
        /// <summary>
        /// Many API requests accept a text_format query parameter that can be used to specify how text content is formatted.
        /// The value for the parameter must be one or more of plain, html, and dom. 
        /// The value returned will be an object with key-value pairs of formats and results:
        ///
        ///`plain` is just plain text, no markup
        ///`html` is a string of unescaped HTML suitable for rendering by a browser
        ///`dom` is a nested object representing and HTML DOM hierarchy that can be used to programmatically present structured content
        /// </summary>
        public static string TextFormat { get; set; }

        public static string AuthorizationToken { get; set; }


        /// <summary>
        /// Creates a new annotation on a public web page. The returned value will be the new annotation object, 
        /// in the same form as would be returned by GET /annotation/:id with the new annotation's ID. More on this here: https://docs.genius.com/#annotations-h2
        /// </summary>
        /// <param name="isPost">Is this a POST request or a PUT request?</param>
        /// <param name="markdown">The text for the note, in markdown(https://help.github.com/articles/github-flavored-markdown/)</param>
        /// <param name="rawAnnotableUrl">The original URL of the page</param>
        /// <param name="fragment">The highlighted fragment</param>
        /// <param name="annotationId">Required if parameter isPost is false.</param>
        /// <param name="beforeHtml">The HTML before the highlighted fragment (prefer up to 200 characters)</param>
        /// <param name="afterHtml">The HTML after the highlighted fragment (prefer up to 200 characters)</param>
        /// <param name="canonicalUrl">The href property of the &lt;link rel="canonical"&gt; tag on the page. 
        /// Including it will help make sure newly created annotation appear on the correct page</param>
        /// <param name="ogUrl">The content property of the &lt;meta property="og:url"&gt; tag on the page. 
        /// Including it will help make sure newly created annotation appear on the correct page</param>
        /// <param name="title">The title of the page</param>
        /// <returns>Annotation</returns>
        public static async Task<Annotation> CreateorUpdateAnnotation(bool isPost, string markdown, string rawAnnotableUrl, string fragment,
            string annotationId = "", string beforeHtml = "", string afterHtml = "", string canonicalUrl = "", string ogUrl = "", string title = "")
        {
            if (string.IsNullOrEmpty(canonicalUrl) && string.IsNullOrEmpty(ogUrl) && string.IsNullOrEmpty(title))
            {
                throw new ArgumentNullException(canonicalUrl, "At least one variable in canonicalUrl || ogUrl || title should be valid");
            }
            using (var client = new HttpClient())
            {
                Uri baseAddress;

                if (isPost == false && !string.IsNullOrEmpty(annotationId))
                {
                    baseAddress = new Uri($"https://api.genius.com/annotations/{annotationId}");
                }
                else if (isPost == false && string.IsNullOrEmpty(annotationId))
                {
                    throw new ArgumentNullException(annotationId, "Can't be empty if the request is PUT");
                }
                else
                {
                    baseAddress = new Uri("https://api.genius.com/annotations");
                }
                var annotationPaylod = new AnnotationPayload
                {
                    Annotation = new Annotation { Body = new AnnotationBody { MarkDown = markdown } },
                    Referent = new Referent
                    {
                        RawAnnotableUrl = rawAnnotableUrl,
                        Fragment = fragment,
                        ContextForDisplay = new ContextForDisplay { BeforeHtml = beforeHtml, AfterHtml = afterHtml }
                    },
                    WebPage = new WebPage { CanonicalUrl = canonicalUrl, OgUrl = ogUrl, Title = title }
                };

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthorizationToken);

                HttpResponseMessage response;
                if (isPost)
                {
                    response = await client.PostAsync(baseAddress,
                        new StringContent(JsonConvert.SerializeObject(annotationPaylod, Formatting.None,
                                new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
                            Encoding.UTF8, "application/json")).ConfigureAwait(false);
                }
                else
                {
                    response = await client.PutAsync(baseAddress,
                        new StringContent(JsonConvert.SerializeObject(annotationPaylod, Formatting.None,
                                new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
                            Encoding.UTF8, "application/json")).ConfigureAwait(false);
                }

                if (!response.IsSuccessStatusCode) return null;
                var annotationObject =
                    JsonConvert.DeserializeObject<Annotation>(response.Content.ReadAsStringAsync().Result);
                return annotationObject;
            }
        }

        /// <summary>
        /// Deletes an annotation created by the authenticated user.
        /// Requires scope: manage_annotation
        /// </summary>
        /// <param name="annotationId">Id of the annotation to be deleted</param>
        /// <returns>Task</returns>
        public static async Task DeleteAnnotation(string annotationId)
        {
            using (var client = new HttpClient())
            {
                var baseAddress = new Uri($"https://api.genius.com/annotations/{annotationId}");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthorizationToken);

                await client.DeleteAsync(baseAddress).ConfigureAwait(false);
            }
        }
    }

    public class AnnotationPayload
    {
        [JsonProperty(PropertyName = "annotation")]
        public Annotation Annotation { get; set; }
        [JsonProperty(PropertyName = "referent")]
        public Referent Referent { get; set; }
        [JsonProperty(PropertyName = "web_page")]
        public WebPage WebPage { get; set; }
    }
}
