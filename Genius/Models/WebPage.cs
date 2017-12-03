using Newtonsoft.Json;

namespace Genius.Models
{
    /// <summary>
    ///     A web page is a single, publicly accessible page to which annotations may be attached.
    ///     https://docs.genius.com/#!#web_pages-h2
    /// </summary>
    public class WebPage
    {
        public string Domain { get; set; }
        public string Id { get; set; }

        [JsonProperty(PropertyName = "normalized_url")]
        public string NormalizedUrl { get; set; }

        [JsonProperty(PropertyName = "share_url")]
        public string ShareUrl { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        public string Url { get; set; }

        [JsonProperty(PropertyName = "annotation_count")]
        public string AnnotationCount { get; set; }

        //Only in POST

        [JsonProperty(PropertyName = "canonical_url")]
        public string CanonicalUrl { get; set; }

        [JsonProperty(PropertyName = "og_url")]
        public string OgUrl { get; set; }
    }
}