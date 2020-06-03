using System.Collections.Generic;
using Jil;

// ReSharper disable ClassNeverInstantiated.Global

namespace Genius.Models.Song
{
  public class SongContributors
  {
    [JilDirective(Name="contributions")]
    public List<string> Contributions { get; set; }
    
    [JilDirective(Name="artist")]
    public Artist.Artist Artist { get; set; }
    
    [JilDirective(Name="user")]
    public User.User User { get; set; }
  }
}