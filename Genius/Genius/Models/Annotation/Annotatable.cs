using Jil;
// ReSharper disable ClassNeverInstantiated.Global

namespace Genius.Models.Annotation
{
  public class Annotatable
  {
    [JilDirective(Name = "api_path")] public string ApiPath { get; set; }
    [JilDirective(Name = "context")] public string Context { get; set; }
    [JilDirective(Name = "id")] public ulong Id { get; set; }
    [JilDirective(Name = "image_url")] public string ImageUrl { get; set; }
    [JilDirective(Name = "link_title")] public string LinkTitle { get; set; }
    [JilDirective(Name = "title")] public string Title { get; set; }
    [JilDirective(Name = "type")] public string Type { get; set; }
    [JilDirective(Name = "url")] public string Url { get; set; }
  }
}