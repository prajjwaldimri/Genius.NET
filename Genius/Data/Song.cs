using Newtonsoft.Json;
using System.Collections.Generic;

namespace Genius.Data
{
	/// <summary>
	/// A song is a document hosted on Genius. It's usually music lyrics.
	/// Data for a song includes details about the document itself and information about all the referents that are attached to it,
	/// including the text to which they refer.
	/// </summary>
	public class Song
	{
		[JsonProperty(PropertyName = "annotation_count")]
		public string AnnotationCount { get; set; }

		[JsonProperty(PropertyName = "api_path")]
		public string ApiPath { get; set; }

		public SongDescription Description { get; set; }

		[JsonProperty(PropertyName = "embed_content")]
		public string EmbedContent { get; set; }

		[JsonProperty(PropertyName = "fact_track")]
		public FactTrack FactTrack { get; set; }

		[JsonProperty(PropertyName = "featured_video")]
		public string FeaturedVideo { get; set; }

		[JsonProperty(PropertyName = "full_title")]
		public string FullTitle { get; set; }

		[JsonProperty(PropertyName = "header_image_thumbnail_url")]
		public string HeaderImageThumbnailUrl { get; set; }

		[JsonProperty(PropertyName = "header_image_url")]
		public string HeaderImageUrl { get; set; }

		public string Id { get; set; }

		[JsonProperty(PropertyName = "lyrics_owner_id")]
		public string LyricsOwnerId { get; set; }

		[JsonProperty(PropertyName = "path")]
		public string Path { get; set; }

		[JsonProperty(PropertyName = "pyongs_count")]
		public string PyongsCount { get; set; }

		[JsonProperty(PropertyName = "recording_location")]
		public string RecordingLocation { get; set; }

		[JsonProperty(PropertyName = "release_date")]
		public string ReleaseDate { get; set; }

		[JsonProperty(PropertyName = "song_art_image_url")]
		public string SongArtImageUrl { get; set; }

		public SongStats Stats { get; set; }

		[JsonProperty(PropertyName = "title")]
		public string Title { get; set; }
		[JsonProperty(PropertyName = "url")]
		public string Url { get; set; }

		[JsonProperty(PropertyName = "current_user_metadata")]
		public CurrentUserMetadata CurrentUserMetadata { get; set; }
		public Album Album { get; set; }

		[JsonProperty(PropertyName = "description_annotation")]
		public SongReferent DescriptionAnnotation { get; set; }

		[JsonProperty(PropertyName = "featured_artists")]
		public List<Artist> FeaturedArtists { get; set; }
		public List<Media> Media { get; set; }

		[JsonProperty(PropertyName = "primary_artist")]
		public Artist PrimaryArtist { get; set; }

		[JsonProperty(PropertyName = "producer_artists")]
		public List<Artist> ProducerArtists { get; set; }

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
		public string AcceptedAnnotations { get; set; }
		public string Contributors { get; set; }
		public bool Hot { get; set; }
		[JsonProperty(PropertyName = "iq_earners")]
		public string IqEarners { get; set; }
		public string PageViews { get; set; }
		public string Transcribers { get; set; }
		[JsonProperty(PropertyName = "unreviewed_annotations")]
		public string UnreviewedAnnotations { get; set; }
		[JsonProperty(PropertyName = "verified_annotations")]
		public string VerifiedAnnotations { get; set; }

	}


}
