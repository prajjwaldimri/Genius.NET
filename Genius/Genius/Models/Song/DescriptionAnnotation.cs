using Jil;
using System.Collections.Generic;

namespace Genius.Models.Song
{
    public class DescriptionAnnotation
    {
        [JilDirective("_type")]
        public string Type { get; set; }

        [JilDirective("annotator_id")]
        public ulong? AnnotatorId { get; set; }

        [JilDirective("annotator_login")]
        public string AnnotatorLogin { get; set; }

        [JilDirective("api_path")]
        public string ApiPath { get; set; }

        [JilDirective("classification")]
        public string Classification { get; set; }

        [JilDirective("fragment")]
        public string Fragment { get; set; }

        [JilDirective("id")]
        public ulong? Id { get; set; }

        [JilDirective("is_description")]
        public bool IsDescription { get; set; }

        [JilDirective("path")]
        public string Path { get; set; }

        [JilDirective("range")]
        public Range Range { get; set; }

        [JilDirective("song_id")]
        public ulong? SongId { get; set; }

        [JilDirective("url")]
        public string Url { get; set; }

        [JilDirective("verified_annotator_ids")]
        public List<object> VerifiedAnnotatorIds { get; set; }

        [JilDirective("annotatable")]
        public Annotatable Annotatable { get; set; }

        [JilDirective("annotations")]
        public List<Annotation> Annotations { get; set; }
    }
}
