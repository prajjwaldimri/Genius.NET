using System.Collections.Generic;
using Genius.Models.User;
using Jil;

// ReSharper disable ClassNeverInstantiated.Global

namespace Genius.Models.Artist
{
  public class Artist
  {
    [JilDirective(Name = "alternate_names")] public List<string> AlternateNames { get; set; }

    [JilDirective(Name = "api_path")] public string ApiPath { get; set; }

    [JilDirective(Name = "description")] public ArtistDescription Description { get; set; }

    [JilDirective(Name = "facebook_name")] public string FacebookName { get; set; }

    [JilDirective(Name = "followers_count")] public ulong FollowersCount { get; set; }

    [JilDirective(Name = "header_image_url")] public string HeaderImageUrl { get; set; }

    [JilDirective(Name = "id")] public ulong Id { get; set; }

    [JilDirective(Name = "image_url")] public string ImageUrl { get; set; }

    [JilDirective(Name = "instagram_name")] public string InstagramName { get; set; }

    [JilDirective(Name = "is_meme_verified")] public bool IsMemeVerified { get; set; }

    [JilDirective(Name = "is_verified")] public bool IsVerified { get; set; }

    [JilDirective(Name = "name")] public string Name { get; set; }

    [JilDirective(Name = "translation_artist")] public bool TranslationArtist { get; set; }

    [JilDirective(Name = "twitter_name")] public string TwitterName { get; set; }

    [JilDirective(Name = "url")] public string Url { get; set; }

    [JilDirective(Name = "current_user_metadata")] public UserMetadata CurrentUserMetadata { get; set; }

    [JilDirective(Name = "iq")] public ulong Iq { get; set; }

    [JilDirective(Name = "description_annotation")] public Referent.Referent DescriptionAnnotation { get; set; }

    [JilDirective(Name = "user")] public User.User User { get; set; }
  }
}