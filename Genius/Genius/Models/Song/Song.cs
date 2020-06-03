// ReSharper disable ClassNeverInstantiated.Global

using System.Collections.Generic;
using Genius.Models.User;
using Jil;

namespace Genius.Models.Song
{
  public class Song
  {
    [JilDirective(Name = "annotation_count")]
    public ulong AnnotationCount { get; set; }

    [JilDirective(Name = "api_path")] public string ApiPath { get; set; }

    [JilDirective(Name = "apple_music_id")]
    public string AppleMusicId { get; set; }

    [JilDirective(Name = "apple_music_player_url")]
    public string AppleMusicPlayerUrl { get; set; }

    [JilDirective(Name = "description")] public SongDescription Description { get; set; }

    [JilDirective(Name = "embed_content")] public string EmbedContent { get; set; }

    [JilDirective(Name = "featured_video")]
    public bool FeaturedVideo { get; set; }

    [JilDirective(Name = "full_title")] public string FullTitle { get; set; }

    [JilDirective(Name = "header_image_thumbnail_url")]
    public string HeaderImageThumbnailUrl { get; set; }

    [JilDirective(Name = "header_image_url")]
    public string HeaderImageUrl { get; set; }

    [JilDirective(Name = "id")] public ulong Id { get; set; }

    [JilDirective(Name = "lyrics_owner_id")]
    public ulong LyricsOwnerId { get; set; }

    [JilDirective(Name = "lyrics_place_holder_reason")]
    public string LyricsPlaceHolderReason { get; set; }

    [JilDirective(Name = "lyrics_state")] public string LyricsState { get; set; }

    [JilDirective(Name = "path")] public string Path { get; set; }

    [JilDirective(Name = "pyongs_count")] public ulong PyongsCount { get; set; }

    [JilDirective(Name = "recording_location")]
    public string RecordingLocation { get; set; }

    [JilDirective(Name = "release_date")] public string ReleaseDate { get; set; }

    [JilDirective(Name = "release_date_for_display")]
    public string ReleaseDateForDisplay { get; set; }

    [JilDirective(Name = "song_art_image_thumbnail_url")]
    public string SongArtImageThumbnailUrl { get; set; }

    [JilDirective(Name = "song_art_image_url")]
    public string SongArtImageUrl { get; set; }

    [JilDirective(Name = "stats")] public SongStats Stats { get; set; }

    [JilDirective(Name = "title")] public string Title { get; set; }

    [JilDirective(Name = "title_with_featured")]
    public string TitleWithFeatured { get; set; }

    [JilDirective(Name = "url")] public string Url { get; set; }

    [JilDirective(Name = "current_user_metadata")]
    public UserMetadata CurrentUserMetadata { get; set; }

    [JilDirective(Name = "album")] public Album Album { get; set; }

    [JilDirective(Name = "custom_performances")]
    public List<SongCustomPerformance> CustomPerformances { get; set; }

    [JilDirective(Name = "description_annotation")]
    public Referent.Referent DescriptionAnnotation { get; set; }

    [JilDirective(Name = "featured_artists")]
    public List<Artist.Artist> FeaturedArtists { get; set; }

    [JilDirective(Name = "lyrics_marked_complete_by")]
    public string LyricsMarkedCompleteBy { get; set; }

    [JilDirective(Name = "media")] public List<Media> Media { get; set; }

    [JilDirective(Name = "primary_artist")]
    public Artist.Artist PrimaryArtist { get; set; }

    [JilDirective(Name = "producer_artists")]
    public List<Artist.Artist> ProducerArtists { get; set; }

    [JilDirective(Name = "song_relationships")]
    public List<SongRelationship> SongRelationships { get; set; }

    [JilDirective(Name = "verified_annotations_by")]
    public List<User.User> VerifiedAnnotationsBy { get; set; }

    [JilDirective(Name = "verified_contributors")]
    public List<SongContributors> VerifiedContributors { get; set; }

    [JilDirective(Name = "verified_lyrics_by")]
    public List<User.User> VerifiedLyricsBy { get; set; }

    [JilDirective(Name = "writer_artists")]
    public List<Artist.Artist> WriterArtists { get; set; }
  }
}