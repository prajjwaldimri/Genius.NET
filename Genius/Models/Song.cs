using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Genius.Models
{
    /// <summary>
    ///     A song is a document hosted on Genius. It's usually music lyrics.
    ///     https://docs.genius.com/#!#songs-h2
    /// </summary>
    public class Song
    {
        [JsonProperty(PropertyName = "annotation_count")]
        public int? AnnotationCount { get; set; }

        [JsonProperty(PropertyName = "api_path")]
        public string ApiPath { get; set; }

        [JsonProperty(PropertyName = "apple_music_id")]
        public string AppleMusicId { get; set; }

        [JsonProperty(PropertyName = "apple_music_player_url")]
        public string AppleMusicPlayerUrl { get; set; }

        public SongDescription Description { get; set; }

        [JsonProperty(PropertyName = "embed_content")]
        public string EmbedContent { get; set; }

        [JsonProperty(PropertyName = "fact_track")]
        public FactTrack FactTrack { get; set; }

        [JsonProperty(PropertyName = "featured_video")]
        public bool? FeaturedVideo { get; set; }

        [JsonProperty(PropertyName = "full_title")]
        public string FullTitle { get; set; }

        [JsonProperty(PropertyName = "header_image_thumbnail_url")]
        public string HeaderImageThumbnailUrl { get; set; }

        [JsonProperty(PropertyName = "header_image_url")]
        public string HeaderImageUrl { get; set; }

        public string Id { get; set; }

        [JsonProperty(PropertyName = "lyrics_owner_id")]
        public string LyricsOwnerId { get; set; }

        [JsonProperty(PropertyName = "lyrics_state")]
        public string LyricsState { get; set; }

        public string Path { get; set; }

        [JsonProperty(PropertyName = "pyongs_count")]
        public int? PyongsCount { get; set; }

        [JsonProperty(PropertyName = "recording_location")]
        public string RecordingLocation { get; set; }

        [JsonProperty(PropertyName = "release_date")]
        public string ReleaseDate { get; set; }

        [JsonProperty(PropertyName = "song_art_image_thumbnail_url")]
        public string SongArtImageThumbnailUrl { get; set; }

        [JsonProperty(PropertyName = "song_art_image_url")]
        public string SongArtImageUrl { get; set; }

        public SongStats Stats { get; set; }
        public string Title { get; set; }
        
        [JsonProperty(PropertyName = "title_with_featured")]
        public string TitleWithFeatured { get; set; }
        
        public string Url { get; set; }

        [JsonProperty(PropertyName = "current_user_metadata")]
        public CurrentUserMetadata CurrentUserMetadata { get; set; }

        public Album Album { get; set; }

        [JsonProperty(PropertyName = "custom_performances")]
        public PerformanceCollection CustomPerformances { get; set; }

        [JsonProperty(PropertyName = "description_annotation")]
        public SongReferent DescriptionAnnotation { get; set; }

        [JsonProperty(PropertyName = "featured_artists")]
        public List<Artist> FeaturedArtists { get; set; }

        public List<Media> Media { get; set; }

        [JsonProperty(PropertyName = "primary_artist")]
        public Artist PrimaryArtist { get; set; }

        [JsonProperty(PropertyName = "producer_artists")]
        public List<Artist> ProducerArtists { get; set; }

        [JsonProperty(PropertyName = "song_relationships")]
        public SongRelationshipCollection SongRelationships { get; set; }

        [JsonProperty(PropertyName = "verified_annotations_by")]
        public List<User> VerifiedAnnotationsBy { get; set; }

        [JsonProperty(PropertyName = "verified_contributors")]
        public List<Contributor> VerifiedContributors { get; set; }

        [JsonProperty(PropertyName = "writer_artists")]
        public List<Artist> WriterArtists { get; set; }
    }

    public class SongDescription
    {
        public SongDom Dom { get; set; }
    }

    public class SongDom
    {
        public string tag { get; set; }
        public List<SongChild> children { get; set; }
    }

    public class SongChild
    {
        public string tag { get; set; }
        public List<object> children { get; set; }
    }

    public class FactTrack
    {
        public string Provider { get; set; }
        public string External_Url { get; set; }
        public string Button_Text { get; set; }
        public string Help_Link_Text { get; set; }
        public string Help_Link_URL { get; set; }
    }

    public class SongStats
    {
        [JsonProperty(PropertyName = "accepted_annotations")]
        public int? AcceptedAnnotations { get; set; }

        public int? Contributors { get; set; }
        public bool? Hot { get; set; }

        [JsonProperty(PropertyName = "iq_earners")]
        public int? IqEarners { get; set; }

        public int? PageViews { get; set; }
        public int? Transcribers { get; set; }

        [JsonProperty(PropertyName = "unreviewed_annotations")]
        public int? UnreviewedAnnotations { get; set; }

        [JsonProperty(PropertyName = "verified_annotations")]
        public int? VerifiedAnnotations { get; set; }
    }

    /// <summary>
    ///     Keys can currently take the following values:
    ///      samples, sampled_in,
    ///      interpolates, interpolated_bym
    ///      cover_of, covered_by,
    ///      remix_of, remixed_by,
    ///      live_version_of, performed_live_as
    /// </summary>
    [JsonConverter(typeof(SongRelationshipCollectionConverter))]
    public class SongRelationshipCollection : Dictionary<string, List<Song>>
    {
        public SongRelationshipCollection() { }
        public SongRelationshipCollection(IDictionary<string, List<Song>> dictionary) : base(dictionary) { }
        public SongRelationshipCollection(int capacity) : base(capacity) { }
    }

    class SongRelationshipCollectionConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var dict = (SongRelationshipCollection) value;
            var list = from relationship in dict
                select new SongRelationship {Type = relationship.Key, Songs = relationship.Value};
            serializer.Serialize(writer, list);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var list = JToken.Load(reader).ToObject<List<SongRelationship>>(serializer);
            var dict = new SongRelationshipCollection(list.Count);
            foreach (var relationship in list)
                dict.Add(relationship.Type, relationship.Songs);
            return dict;
        }

        public override bool CanConvert(Type objectType)
            => typeof(SongRelationshipCollection).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());

        class SongRelationship
        {
            public string Type  { get; set; }
            public List<Song> Songs { get; set; }
        }
    }
}