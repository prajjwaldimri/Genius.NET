// ReSharper disable ClassNeverInstantiated.Global

using Jil;

namespace Genius.Models.Song
{
  public class Album
  {
    [JilDirective(Name = "api_path")] public string ApiPath { get; set; }
    
    [JilDirective(Name = "cover_art_url")] public string CoverArtUrl { get; set; }
    
    [JilDirective(Name = "full_title")] public string FullTitle { get; set; }
    
    [JilDirective(Name = "id")] public ulong Id { get; set; }
    
    [JilDirective(Name = "name")] public string Name { get; set; }
    
    [JilDirective(Name = "url")] public string Url { get; set; }
    
    [JilDirective(Name = "artist")] public Artist.Artist Artist { get; set; }
  }
}