// ReSharper disable ClassNeverInstantiated.Global

using System.Collections.Generic;
using Jil;

namespace Genius.Models.Response
{
  public class ArtistsSongsResponse
  {
    [JilDirective(Name = "meta")] public Meta Meta { get; set; }

    [JilDirective(Name = "response")] public ArtistsSongsData Response { get; set; }
  }

  public class ArtistsSongsData
  {
    [JilDirective(Name = "songs")] public List<Song.Song> Songs { get; set; }
    
    [JilDirective(Name = "next_page")] public ulong NextPage { get; set; }
  }
}