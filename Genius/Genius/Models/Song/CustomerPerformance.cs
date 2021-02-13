using Jil;
using System.Collections.Generic;

namespace Genius.Models.Song
{
  public class CustomPerformance
  {
    [JilDirective("label")]
    public string Label { get; set; }

    [JilDirective("artists")]
    public List<Artist.Artist> Artists { get; set; }
  }
}
