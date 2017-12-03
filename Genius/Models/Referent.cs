using System.Collections.Generic;
using Newtonsoft.Json;

namespace Genius.Models
{
    /// <summary>
    ///     Referents are the sections of a piece of content to which annotations are attached.
    ///     https://docs.genius.com/#!#referents-h2
    /// </summary>
    public class Referent
    {
        [JsonProperty(PropertyName = "_type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "annotator_id")]
        public string AnnotatorId { get; set; }

        [JsonProperty(PropertyName = "annotator_login")]
        public string AnnotatorLogin { get; set; }

        [JsonProperty(PropertyName = "api_path")]
        public string ApiPath { get; set; }

        public string Classification { get; set; }
        public string Featured { get; set; }

        [JsonProperty(PropertyName = "fragment")]
        public string Fragment { get; set; }

        public string Id { get; set; }

        [JsonProperty(PropertyName = "is_description")]
        public string IsDescription { get; set; }

        public string Path { get; set; }
        public ReferentRange Range { get; set; }

        [JsonProperty(PropertyName = "song_id")]
        public string SongId { get; set; }

        public string Url { get; set; }
        public List<Annotation> Annotations { get; set; }
        public Annotatable Annotatable { get; set; }

        [JsonProperty(PropertyName = "verified_annotator_ids")]
        public List<string> VerifiedAnnotatorIds { get; set; }

        [JsonProperty(PropertyName = "raw_annotatable_url")]

        //Used in POST
        public string RawAnnotableUrl { get; set; }

        [JsonProperty(PropertyName = "context_for_display")]
        public ContextForDisplay ContextForDisplay { get; set; }
    }

    /// <summary>
    ///     A Variation of Referent to be used by Song Class
    /// </summary>
    public class SongReferent : Referent
    {
        public new List<SongAnnotation> Annotations { get; set; }
    }

    /// <summary>
    ///     Information for anchoring the referent in the source text
    /// </summary>
    public class ReferentRange
    {
        public string Start { get; set; }
        public string StartOffset { get; set; }
        public string End { get; set; }
        public string EndOffset { get; set; }
        public string Before { get; set; }
        public string After { get; set; }
        public string Content { get; set; }
    }

    public class ContextForDisplay
    {
        [JsonProperty(PropertyName = "before_html")]
        public string BeforeHtml { get; set; }

        [JsonProperty(PropertyName = "after_html")]
        public string AfterHtml { get; set; }
    }

    /// <summary>
    ///     Meta-data about the annotated document
    /// </summary>
    public class Annotatable
    {
        public string Api_Path { get; set; }
        public string Context { get; set; }
        public string Id { get; set; }
        public string Image_Url { get; set; }
        public string Link_Title { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string URL { get; set; }
    }

    /// <summary>
    ///     Plural Referent Class
    /// </summary>
    public class Referents
    {
        public List<Referent> Referent { get; set; }
    }
}