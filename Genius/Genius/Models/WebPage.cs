// ReSharper disable ClassNeverInstantiated.Global

using Jil;

namespace Genius.Models
{
    public class WebPage
  {
    [JilDirective(Name = "api_path")] public string ApiPath { get; set; }

    [JilDirective(Name = "domain")] public string Domain { get; set; }

    [JilDirective(Name = "id")] public ulong Id { get; set; }

    [JilDirective(Name = "normalized_url")]
    public string NormalizedUrl { get; set; }

    [JilDirective(Name = "share_url")] public string ShareUrl { get; set; }

    [JilDirective(Name = "title")] public string Title { get; set; }

    [JilDirective(Name = "url")] public string Url { get; set; }

    [JilDirective(Name = "annotation_count")]
    public ulong AnnotationCount { get; set; }
  }
}