using System.Collections.Generic;
using Jil;

namespace Genius.Models
{
  public class SearchHit
  {
    [JilDirective(Name = "highlights")] public List<string> Highlights { get; set; }

    [JilDirective(Name = "index")] public string Index { get; set; }

    [JilDirective(Name = "type")] public string Type { get; set; }

    [JilDirective(Name = "result")] public Song.Song Result { get; set; }
  }
}