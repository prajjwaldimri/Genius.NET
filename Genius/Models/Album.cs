using Newtonsoft.Json;

namespace Genius.Models
{
    /// <summary>
    ///     The album to which a song belongs to. This is returned inside the song object from server.
    /// </summary>
    public class Album
    {
        [JsonProperty(PropertyName = "api_path")]
        public string ApiPath { get; set; }

        [JsonProperty(PropertyName = "cover_art_url")]
        public string CoverArtUrl { get; set; }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public Artist Artist { get; set; }
    }
}