using System.Collections.Generic;
using Newtonsoft.Json;

namespace Genius.Models
{
    /// <summary>
    ///     An artist is how Genius represents the creator of one or more songs (or other documents hosted on Genius).
    ///     It's usually a musician or group of musicians.
    ///     https://docs.genius.com/#artists-h2
    /// </summary>
    public class Artist
    {
        [JsonProperty(PropertyName = "alternate_names")]
        public List<object> AlternateNames { get; set; }

        [JsonProperty(PropertyName = "api_path")]
        public string ApiPath { get; set; }

        [JsonProperty(PropertyName = "facebook_name")]
        public string FacebookName { get; set; }

        [JsonProperty(PropertyName = "followers_count")]
        public string FollowersCount { get; set; }

        [JsonProperty(PropertyName = "header_image_url")]
        public string HeaderImageUrl { get; set; }

        public string Id { get; set; }

        [JsonProperty(PropertyName = "image_url")]
        public string ImageUrl { get; set; }

        [JsonProperty(PropertyName = "instagram_name")]
        public string InstagramName { get; set; }

        [JsonProperty(PropertyName = "is_meme_verified")]
        public string IsMemeVerified { get; set; }

        [JsonProperty(PropertyName = "is_verified")]
        public string IsVerified { get; set; }

        public string Name { get; set; }
        public string Url { get; set; }

        [JsonProperty(PropertyName = "current_user_metadata")]
        public CurrentUserMetadata CurrentUserMetadata { get; set; }

        public string Iq { get; set; }

        [JsonProperty(PropertyName = "description_annotation")]
        public SongReferent DescriptionAnnotation { get; set; }

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