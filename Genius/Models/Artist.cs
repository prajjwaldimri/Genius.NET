using System.Collections.Generic;

namespace Genius.Models
{
    /// <summary>
    ///     An artist is how Genius represents the creator of one or more songs (or other documents hosted on Genius).
    ///     It's usually a musician or group of musicians.
    ///     https://docs.genius.com/#artists-h2
    /// </summary>
    public class Artist
    {
        public List<object> AlternateNames { get; set; }
        public string ApiPath { get; set; }
        public string FacebookName { get; set; }
        public string FollowersCount { get; set; }
        public string HeaderImageUrl { get; set; }
        public string Id { get; set; }
        public string ImageUrl { get; set; }
        public string InstagramName { get; set; }
        public bool? IsMemeVerified { get; set; }
        public bool? IsVerified { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public CurrentUserMetadata CurrentUserMetadata { get; set; }
        public int? Iq { get; set; }
        public Referent DescriptionAnnotation { get; set; }
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