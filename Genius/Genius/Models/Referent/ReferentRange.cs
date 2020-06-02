// ReSharper disable ClassNeverInstantiated.Global

using Jil;

namespace Genius.Models.Referent
{
  public class ReferentRange
  {
    [JilDirective(Name = "start")] public string Start { get; set; }

    [JilDirective(Name = "startOffset")] public string StartOffset { get; set; }

    [JilDirective(Name = "end")] public string End { get; set; }

    [JilDirective(Name = "endOffset")] public string EndOffset { get; set; }

    [JilDirective(Name = "before")] public string Before { get; set; }

    [JilDirective(Name = "after")] public string After { get; set; }

    [JilDirective(Name = "content")] public string Content { get; set; }
  }
}