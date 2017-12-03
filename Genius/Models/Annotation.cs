using System.Collections.Generic;
using Newtonsoft.Json;

namespace Genius.Models
{
    /// <summary>
    ///     An annotation is a piece of content about a part of a document.
    ///     The document may be a song (hosted on Genius) or a web page (hosted anywhere).
    ///     The part of a document that an annotation is attached to is called a referent.
    ///     Annotation data returned from the API includes both the substance of the annotation and the necessary information
    ///     for displaying it in
    ///     its original context.
    ///     More here: https://docs.genius.com/#annotations-h2
    /// </summary>
    public class Annotation
    {
        [JsonProperty(PropertyName = "api_path")]
        public string ApiPath { get; set; }

        /// <summary>
        ///     The Content of The Annotation
        /// </summary>

        [JsonProperty(PropertyName = "body")]
        public AnnotationBody Body { get; set; }

        /// <summary>
        ///     Total Number of Comments in Annotation
        /// </summary>
        [JsonProperty(PropertyName = "comment_count")]
        public string CommentCount { get; set; }

        public string Community { get; set; }

        [JsonProperty(PropertyName = "has_voters")]
        public string HasVoters { get; set; }

        /// <summary>
        ///     ID of The Annotation
        /// </summary>
        public string Id { get; set; }

        public string Pinned { get; set; }

        [JsonProperty(PropertyName = "shared_url")]
        public string SharedUrl { get; set; }

        public string Source { get; set; }
        public string State { get; set; }

        /// <summary>
        ///     Full URL to the referent on genius.com
        /// </summary>
        public string Url { get; set; }

        public string Verified { get; set; }

        /// <summary>
        ///     Total vote score "upvotes and downvotes"
        /// </summary>

        [JsonProperty(PropertyName = "votes_total")]
        public string VotesTotal { get; set; }

        /// <summary>
        ///     List of users who contributed to this annotation
        /// </summary>
        public List<Author> Authors { get; set; }

        /// <summary>
        ///     List of users who have cosigned this annotation
        /// </summary>
        [JsonProperty(PropertyName = "cosigned_by")]
        public List<User> CosignedBy { get; set; }

        /// <summary>
        ///     Verified User that created this annotation
        /// </summary>
        [JsonProperty(PropertyName = "verified_by")]
        public User VerifiedBy { get; set; }
    }

    #region Classes for body element of Annotation

    public class AnnotationBody
    {
        [JsonProperty(PropertyName = "dom")]
        public AnnotationDom Dom { get; set; }

        [JsonProperty(PropertyName = "markdown")]
        public string MarkDown { get; set; }

        [JsonProperty(PropertyName = "plain")]
        public string Plain { get; set; }
    }

    public class AnnotationDom
    {
        [JsonProperty(PropertyName = "tag")]
        public string Tag { get; set; }

        [JsonProperty(PropertyName = "children")]
        public AnnotationChild[] Children { get; set; }
    }

    public class AnnotationChild
    {
        [JsonProperty(PropertyName = "tag")]
        public string Tag { get; set; }

        [JsonProperty(PropertyName = "children")]
        public object[] Children { get; set; }
    }

    #endregion

    /// <summary>
    ///     A variation of Annotation used with Song Class
    /// </summary>
    public class SongAnnotation : Annotation
    {
        public new SongAnnotationBody Body { get; set; }
    }

    // Derived Classes of Annotation Body because the body component for annotations is
    // different when we are calling API using Song ID.

    public class SongAnnotationBody : AnnotationBody
    {
        public new SongandUserAnnotationDom Dom { get; set; }
    }

    public class SongandUserAnnotationDom : AnnotationDom
    {
        public new List<SongandUserAnnotationChild> Children { get; set; }
    }

    public class SongandUserAnnotationChild : AnnotationChild
    {
        public new List<object> Children { get; set; }
    }

    /// <summary>
    ///     Types of vote on Annotation
    /// </summary>
    public enum VoteType
    {
        Upvote,
        Downvote,
        Unvote
    }
}