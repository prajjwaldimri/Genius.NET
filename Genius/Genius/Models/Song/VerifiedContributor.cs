// ReSharper disable ClassNeverInstantiated.Global

using Jil;
using System.Collections.Generic;

namespace Genius.Models.Song
{
  public class VerifiedContributor
  {
    [JilDirective("contributions")]
    public List<string> Contributions { get; set; }

    [JilDirective("artist")]
    public Artist.Artist Artist { get; set; }

    [JilDirective("user")]
    public VerifiedAnnotationsBy User { get; set; }
  }
}