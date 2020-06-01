using Jil;

namespace Genius.Models
{
  public class Avatar
  {
    [JilDirective(Name = "url")] public string Url { get; set; }

    // The Bounding box height is constant.
  }
}