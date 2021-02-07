// ReSharper disable ClassNeverInstantiated.Global

using System.Collections.Generic;
using Genius.Models.User;
using Jil;

namespace Genius.Models.Song
{
    public class Song
    {
        [JilDirective("annotation_count")]
        public ulong? AnnotationCount { get; set; }

        [JilDirective("api_path")]
        public string ApiPath { get; set; }

        [JilDirective("apple_music_id")]
        public string AppleMusicId { get; set; }

        [JilDirective("apple_music_player_url")]
        public string AppleMusicPlayerUrl { get; set; }

        [JilDirective("description")]
        public Description Description { get; set; }

        [JilDirective("embed_content")]
        public string EmbedContent { get; set; }

        [JilDirective("featured_video")]
        public bool FeaturedVideo { get; set; }

        [JilDirective("full_title")]
        public string FullTitle { get; set; }

        [JilDirective("header_image_thumbnail_url")]
        public string HeaderImageThumbnailUrl { get; set; }

        [JilDirective("header_image_url")]
        public string HeaderImageUrl { get; set; }

        [JilDirective("id")]
        public ulong? Id { get; set; }

        [JilDirective("lyrics_owner_id")]
        public ulong? LyricsOwnerId { get; set; }

        [JilDirective("lyrics_placeholder_reason")]
        public object LyricsPlaceholderReason { get; set; }

        [JilDirective("lyrics_state")]
        public string LyricsState { get; set; }

        [JilDirective("path")]
        public string Path { get; set; }

        [JilDirective("pyongs_count")]
        public ulong? PyongsCount { get; set; }

        [JilDirective("recording_location")]
        public object RecordingLocation { get; set; }

        [JilDirective("release_date")]
        public string ReleaseDate { get; set; }

        [JilDirective("release_date_for_display")]
        public string ReleaseDateForDisplay { get; set; }

        [JilDirective("song_art_image_thumbnail_url")]
        public string SongArtImageThumbnailUrl { get; set; }

        [JilDirective("song_art_image_url")]
        public string SongArtImageUrl { get; set; }

        [JilDirective("stats")]
        public Stats Stats { get; set; }

        [JilDirective("title")]
        public string Title { get; set; }

        [JilDirective("title_with_featured")]
        public string TitleWithFeatured { get; set; }

        [JilDirective("url")]
        public string Url { get; set; }

        [JilDirective("current_user_metadata")]
        public SongCurrentUserMetadata CurrentUserMetadata { get; set; }

        [JilDirective("album")]
        public object Album { get; set; }

        [JilDirective("custom_performances")]
        public List<CustomPerformance> CustomPerformances { get; set; }

        [JilDirective("description_annotation")]
        public DescriptionAnnotation DescriptionAnnotation { get; set; }

        [JilDirective("featured_artists")]
        public List<Artist.Artist> FeaturedArtists { get; set; }

        [JilDirective("lyrics_marked_complete_by")]
        public object LyricsMarkedCompleteBy { get; set; }

        [JilDirective("media")]
        public List<Media> Media { get; set; }

        [JilDirective("primary_artist")]
        public Artist.Artist PrimaryArtist { get; set; }

        [JilDirective("producer_artists")]
        public List<Artist.Artist> ProducerArtists { get; set; }

        [JilDirective("song_relationships")]
        public List<SongRelationship> SongRelationships { get; set; }

        [JilDirective("verified_annotations_by")]
        public List<VerifiedAnnotationsBy> VerifiedAnnotationsBy { get; set; }

        [JilDirective("verified_contributors")]
        public List<VerifiedContributor> VerifiedContributors { get; set; }

        [JilDirective("verified_lyrics_by")]
        public List<VerifiedAnnotationsBy> VerifiedLyricsBy { get; set; }

        [JilDirective("writer_artists")]
        public List<Artist.Artist> WriterArtists { get; set; }
    }
}