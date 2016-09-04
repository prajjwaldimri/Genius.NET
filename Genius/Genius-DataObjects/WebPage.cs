using Newtonsoft.Json;

namespace Genius
{
    public class WebPage
    {
        public string Domain { get; set; }
        public string Id { get; set; }

        [JsonProperty(PropertyName = "normalized_url")]
        public string NormalizedUrl { get; set; }

        [JsonProperty(PropertyName = "share_url")]
        public string ShareUrl { get; set; }

        public string Title { get; set; }
        public string Url { get; set; }

        [JsonProperty(PropertyName = "annotation_count")]
        public string AnnotationCount { get; set; }

    }

}
