using System.Collections.Generic;
using Newtonsoft.Json;

namespace Genius.Data
{
	/// <summary>
	/// A given artist.
	/// </summary>
	public class Artist
    {
		/// <summary>
		/// Alternate names of the artists.
		/// </summary>
        [JsonProperty(PropertyName = "alternate_names")]
        public List<object> AlternateNames { get; set; }

		/// <summary>
		/// The API-Path to the artist.
		/// </summary>
        [JsonProperty(PropertyName = "api_path")]
        public string ApiPath { get; set; }

		/// <summary>
		/// The facebook name of the artist.
		/// </summary>
        [JsonProperty(PropertyName = "facebook_name")]
        public string FacebookName { get; set; }

		/// <summary>
		/// The amount of twitter followers this artist has.
		/// </summary>
        [JsonProperty(PropertyName = "followers_count")]
        public string FollowersCount { get; set; }

		/// <summary>
		/// The url to the header image of this artists.
		/// </summary>
        [JsonProperty(PropertyName = "header_image_url")]
        public string HeaderImageUrl { get; set; }
		/// <summary>
		/// The id of this artist.
		/// </summary>
        public string Id { get; set; }

		/// <summary>
		/// The url to the image of this artist.
		/// </summary>
        [JsonProperty(PropertyName = "image_url")]
        public string ImageUrl { get; set; }

		/// <summary>
		/// The instagram name of this artist.
		/// </summary>
        [JsonProperty(PropertyName = "instagram_name")]
        public string InstagramName { get; set; }

		/// <summary>
		/// Whether it is verified or not.
		/// </summary>
        [JsonProperty(PropertyName = "is_meme_verified")]
        public string IsMemeVerified { get; set; }

		/// <summary>
		/// Whether this artist is verified or not.
		/// </summary>
        [JsonProperty(PropertyName = "is_verified")]
        public string IsVerified { get; set; }
		/// <summary>
		/// The name of this artist.
		/// </summary>
        public string Name { get; set; }
		/// <summary>
		/// The url of this artist (e.g. website).
		/// </summary>
        public string Url { get; set; }

		/// <summary>
		/// The current user metadata of this artist.
		/// </summary>
        [JsonProperty(PropertyName = "current_user_metadata")]
        public CurrentUserMetadata CurrentUserMetadata { get; set; }
		/// <summary>
		/// The IQ-Points of this artist.
		/// </summary>
        public string Iq { get; set; }

		/// <summary>
		/// The description annotation.
		/// </summary>
        [JsonProperty(PropertyName = "description_annotation")]
        public SongReferent DescriptionAnnotation { get; set; }

		/// <summary>
		/// The user this artist belongs to.
		/// </summary>
        public User User { get; set; }
    }

    public class ArtistDescription
    {
        public ArtistDom Dom { get; set; }
    }

    public class ArtistDom
    {
        public string Tag { get; set; }
        public List<object> Children { get; set; }
    }
}
