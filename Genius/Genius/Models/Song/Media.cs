using Jil;

// ReSharper disable ClassNeverInstantiated.Global

namespace Genius.Models.Song
{
  public class Media
  {
    [JilDirective(Name = "provider")] public string Provider { get; set; }
    
    [JilDirective(Name = "start")] public ulong Start { get; set; }
    
    [JilDirective(Name = "type")] public string Type { get; set; }
    
    [JilDirective(Name = "url")] public string Url { get; set; }
  }
}