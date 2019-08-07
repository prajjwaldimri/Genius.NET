using System.Collections.Generic;
using Newtonsoft.Json;

namespace Genius.Models
{
    public class Album
    {
        [JsonProperty(PropertyName = "api_path")]
        public string ApiPath { get; set; }

        [JsonProperty(PropertyName = "comment_count")]
        public int CommentCount { get; set; }

        [JsonProperty(PropertyName = "cover_art_url")]
        public string CoverArtUrl { get; set; }

        [JsonProperty(PropertyName = "custom_header_image_url")]
        public string CustomHeaderImageUrl { get; set; }

        [JsonProperty(PropertyName = "full_title")]
        public string FullTitle { get; set; }

        [JsonProperty(PropertyName = "header_image_url")]
        public string HeaderImageUrl { get; set; }

        public string Id { get; set; }

        [JsonProperty(PropertyName = "lock_state")]
        public string LockState { get; set; }

        public string Name { get; set; }

        [JsonProperty(PropertyName = "pyongs_count")]
        public int PyongsCount { get; set; }

        [JsonProperty(PropertyName = "release_date")]
        public string ReleaseDate { get; set; }

        [JsonProperty(PropertyName = "release_date_components")]
        public ReleaseDateComponents ReleaseDateComponents { get; set; }

        public string Url { get; set; }

        [JsonProperty(PropertyName = "current_user_metadata")]
        public CurrentUserMetadata CurrentUserMetadata { get; set; }

        [JsonProperty(PropertyName = "song_pageviews")]
        public int SongPageviews { get; set; }

        public Artist Artist { get; set; }

        [JsonProperty(PropertyName = "cover_arts")]
        public List<AlbumCoverArt> CoverArts { get; set; }

        [JsonProperty(PropertyName = "description_annotation")]
        public SongReferent DescriptionAnnotation { get; set; }

        [JsonProperty(PropertyName = "performance_groups")]
        public PerformanceCollection PerformanceGroups { get; set; }

        [JsonProperty(PropertyName = "song_performances")]
        public PerformanceCollection SongPerformances { get; set; }

        public class AlbumCoverArt
        {
            public bool Annotated { get; set; }
            
            [JsonProperty(PropertyName = "api_path")]
            public string ApiPath { get; set; }

            public string Id { get; set; }

            [JsonProperty(PropertyName = "image_url")]
            public string ImageUrl { get; set; }

            [JsonProperty(PropertyName = "thumbnail_image_url")]
            public string ThumbnailImageUrl { get; set; }

            public string Url { get; set; }
        }
    }
}