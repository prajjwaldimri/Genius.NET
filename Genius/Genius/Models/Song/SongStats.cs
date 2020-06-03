// ReSharper disable ClassNeverInstantiated.Global

using Jil;

namespace Genius.Models.Song
{
  public class SongStats
  {
    [JilDirective(Name = "accepted_annotations")]
    public ulong AcceptedAnnotations { get; set; }

    [JilDirective(Name = "contributors")] public ulong Contributors { get; set; }

    [JilDirective(Name = "iq_earners")] public ulong IqEarners { get; set; }

    [JilDirective(Name = "transcribers")] public ulong Transcribers { get; set; }

    [JilDirective(Name = "unreviewed_annotations")]
    public ulong UnreviewedAnnotations { get; set; }

    [JilDirective(Name = "verified_annotations")]
    public ulong VerifiedAnnotations { get; set; }

    [JilDirective(Name = "concurrents")] public ulong Concurrents { get; set; }

    [JilDirective(Name = "hot")] public bool Hot { get; set; }

    [JilDirective(Name = "pageviews")] public ulong PageViews { get; set; }
  }
}