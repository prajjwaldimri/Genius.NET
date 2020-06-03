using System.Collections.Generic;
using Jil;
// ReSharper disable ClassNeverInstantiated.Global

namespace Genius.Models.Song
{
  public class SongCustomPerformance
  {
    [JilDirective(Name="label")]
    public string Label { get; set; }
    
    [JilDirective(Name="artists")]
    public List<Artist.Artist> Artists { get; set; }
  }
}