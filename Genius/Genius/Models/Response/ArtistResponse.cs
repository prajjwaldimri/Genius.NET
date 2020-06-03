// ReSharper disable ClassNeverInstantiated.Global

using Jil;

namespace Genius.Models.Response
{
  public class ArtistResponse
  {
    [JilDirective(Name = "meta")] public Meta Meta { get; set; }

    [JilDirective(Name = "response")] public ArtistData Response { get; set; }
  }

  
  
  public class ArtistData
  {
    [JilDirective(Name = "artist")] public Artist.Artist Artist { get; set; }
  }
}