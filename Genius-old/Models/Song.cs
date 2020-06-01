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
        public int? AnnotationCount { get; set; }
        public string ApiPath { get; set; }
        public string AppleMusicId { get; set; }
        public string AppleMusicPlayerUrl { get; set; }
        public SongDescription Description { get; set; }
        public string EmbedContent { get; set; }
        public FactTrack FactTrack { get; set; }
        public bool? FeaturedVideo { get; set; }
        public string FullTitle { get; set; }
        public string HeaderImageThumbnailUrl { get; set; }
        public string HeaderImageUrl { get; set; }
        public string Id { get; set; }
        public string LyricsOwnerId { get; set; }
        public string LyricsState { get; set; }
        public string Path { get; set; }
        public int? PyongsCount { get; set; }
        public string RecordingLocation { get; set; }
        public string ReleaseDate { get; set; }
        public string SongArtImageThumbnailUrl { get; set; }
        public string SongArtImageUrl { get; set; }
        public SongStats Stats { get; set; }
        public string Title { get; set; }
        public string TitleWithFeatured { get; set; }
        public string Url { get; set; }
        public CurrentUserMetadata CurrentUserMetadata { get; set; }
        public Album Album { get; set; }
        public PerformanceCollection CustomPerformances { get; set; }
        public Referent DescriptionAnnotation { get; set; }
        public List<Artist> FeaturedArtists { get; set; }
        public List<Media> Media { get; set; }
        public Artist PrimaryArtist { get; set; }
        public List<Artist> ProducerArtists { get; set; }
        public SongRelationshipCollection SongRelationships { get; set; }
        public List<User> VerifiedAnnotationsBy { get; set; }
        public List<Contributor> VerifiedContributors { get; set; }
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
        public int? AcceptedAnnotations { get; set; }
        public int? Contributors { get; set; }
        public bool? Hot { get; set; }
        public int? IqEarners { get; set; }

        [JsonProperty("pageviews")]
        public int? PageViews { get; set; }

        public int? Transcribers { get; set; }
        public int? UnreviewedAnnotations { get; set; }
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