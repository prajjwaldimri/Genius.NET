using Jil;

namespace Genius.Models.Song
{
    public class Stats
    {
        [JilDirective("accepted_annotations")]
        public ulong? AcceptedAnnotations { get; set; }

        [JilDirective("contributors")]
        public ulong? Contributors { get; set; }

        [JilDirective("iq_earners")]
        public ulong? IqEarners { get; set; }

        [JilDirective("transcribers")]
        public ulong? Transcribers { get; set; }

        [JilDirective("unreviewed_annotations")]
        public ulong? UnreviewedAnnotations { get; set; }

        [JilDirective("verified_annotations")]
        public ulong? VerifiedAnnotations { get; set; }

        [JilDirective("hot")]
        public bool Hot { get; set; }
    }
}
