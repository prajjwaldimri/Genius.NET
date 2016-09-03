using System;
using System.Collections.Generic;

namespace Genius
{
    /// <summary>
    /// An annotation is a piece of content about a part of a document. 
    /// The document may be a song (hosted on Genius) or a web page (hosted anywhere). 
    /// The part of a document that an annotation is attached to is called a referent.
    /// Annotation data returned from the API includes both the substance of the annotation and the necessary information for displaying it in
    /// its original context.
    /// More here: https://docs.genius.com/#annotations-h2
    /// </summary>
    public class Annotation
    {
        public string Api_Path { get; set; }
        /// <summary>
        /// The Content of The Annotation
        /// </summary>
        public AnnotationBody body { get; set; }
        /// <summary>
        /// Total Number of Comments in Annotation
        /// </summary>
        public string Comment_Count { get; set; }
        public bool Community { get; set; }
        public bool Has_Voters { get; set; }
        /// <summary>
        /// ID of The Annotation
        /// </summary>
        public string Id { get; set; }
        public bool Pinned { get; set; }
        public string Shared_Url { get; set; }
        public string Source { get; set; }
        public string State { get; set; }
        /// <summary>
        /// Full URL to the referent on genius.com
        /// </summary>
        public string Url { get; set; }
        public bool Verified { get; set; }
        /// <summary>
        /// Total vote score "upvotes and downvotes"
        /// </summary>
        public string Votes_Total { get; set; }
        /// <summary>
        /// List of users who contributed to this annotation
        /// </summary>
        public List<Author> Authors { get; set; }
        /// <summary>
        /// List of users who have cosigned this annotation
        /// </summary>
        public List<User> Cosigned_By { get; set; }
        /// <summary>
        /// Verified User that created this annotation
        /// </summary>
        public User Verified_By { get; set; }

    }

    public class AnnotationBody
    {
        public Dom dom { get; set; }
    }

    public class Dom
    {
        public string tag { get; set; }
        public Child[] children { get; set; }
    }

    public class Child
    {
        public string tag { get; set; }
        public string[] children { get; set; }
    }

}
