using System.Collections.Generic;

namespace Genius.Models
{
    public class Album
    {
        public string ApiPath { get; set; }
        public int? CommentCount { get; set; }
        public string CoverArtUrl { get; set; }
        public string CustomHeaderImageUrl { get; set; }
        public string FullTitle { get; set; }
        public string HeaderImageUrl { get; set; }
        public string Id { get; set; }
        public string LockState { get; set; }
        public string Name { get; set; }
        public int? PyongsCount { get; set; }
        public string ReleaseDate { get; set; }
        public ReleaseDateComponents ReleaseDateComponents { get; set; }
        public string Url { get; set; }
        public CurrentUserMetadata CurrentUserMetadata { get; set; }
        public int? SongPageviews { get; set; }
        public Artist Artist { get; set; }
        public List<AlbumCoverArt> CoverArts { get; set; }
        public Referent DescriptionAnnotation { get; set; }
        public PerformanceCollection PerformanceGroups { get; set; }
        public PerformanceCollection SongPerformances { get; set; }

        public class AlbumCoverArt
        {
            public bool Annotated { get; set; }
            public string ApiPath { get; set; }
            public string Id { get; set; }
            public string ImageUrl { get; set; }
            public string ThumbnailImageUrl { get; set; }
            public string Url { get; set; }
        }
    }
}