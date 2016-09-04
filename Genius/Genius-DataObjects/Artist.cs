using Newtonsoft.Json;

namespace Genius
{
    public class Artist
    {
        [JsonProperty(PropertyName = "api_path")]
        public string ApiPath { get; set; }

        [JsonProperty(PropertyName = "header_image_url")]
        public string HeaderImageUrl { get; set; }
        public string Id { get; set; }

        [JsonProperty(PropertyName = "image_url")]
        public string ImageUrl { get; set; }

        [JsonProperty(PropertyName = "is_meme_verified")]
        public bool IsMemeVerified { get; set; }

        [JsonProperty(PropertyName = "is_verified")]
        public bool IsVerified { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Iq { get; set; }
    }
}
