using Jil;
// ReSharper disable ClassNeverInstantiated.Global

namespace Genius.Models.Song
{
  public class SongDescription
  {
    [JilDirective(Name="dom")]
    public Dom Dom { get; set; }
  }
}