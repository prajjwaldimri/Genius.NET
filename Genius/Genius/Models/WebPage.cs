// ReSharper disable ClassNeverInstantiated.Global

using System.Collections.Generic;
using Jil;

namespace Genius.Models
{
  public class WebPage
  {
    [JilDirective(Name = "api_path")] private string ApiPath { get; set; }

    [JilDirective(Name = "domain")] private string Domain { get; set; }

    [JilDirective(Name = "id")] private ulong Id { get; set; }

    [JilDirective(Name = "normalized_url")]
    private string NormalizedUrl { get; set; }

    [JilDirective(Name = "share_url")] private string ShareUrl { get; set; }

    [JilDirective(Name = "title")] private string Title { get; set; }

    [JilDirective(Name = "url")] private string Url { get; set; }

    [JilDirective(Name = "annotation_count")]
    private ulong AnnotationCount { get; set; }
  }
}