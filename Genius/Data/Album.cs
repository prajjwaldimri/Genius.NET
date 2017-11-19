using Newtonsoft.Json;

namespace Genius.Data
{
	/// <summary>
	/// An album.
	/// </summary>
	public class Album
    {
		/// <summary>
		/// The api path to the album.
		/// </summary>
        [JsonProperty(PropertyName = "api_path")]
        public string ApiPath { get; set; }

		/// <summary>
		/// The url for the cover art.
		/// </summary>
        [JsonProperty(PropertyName = "cover_art_url")]
        public string CoverArtUrl { get; set; }
		/// <summary>
		/// The id for the album.
		/// </summary>
        public string Id { get; set; }
		/// <summary>
		/// The name of the album
		/// </summary>
        public string Name { get; set; }
		/// <summary>
		/// The url to the album.
		/// </summary>
        public string Url { get; set; }
		/// <summary>
		/// The artist of the album.
		/// </summary>
        public Artist Artist { get; set; }
    }
}
