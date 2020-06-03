// ReSharper disable ClassNeverInstantiated.Global

using Jil;

namespace Genius.Models.Response
{
  public class SongResponse
  {
    [JilDirective(Name = "meta")] public Meta Meta { get; set; }

    [JilDirective(Name = "response")] public SongData Response { get; set; }
  }

  public class SongData
  {
    [JilDirective(Name = "song")] public Song.Song Song { get; set; }
  }
}