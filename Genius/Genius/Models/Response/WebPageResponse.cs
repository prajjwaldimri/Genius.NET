// ReSharper disable ClassNeverInstantiated.Global

using Jil;

namespace Genius.Models.Response
{
  public class WebPageResponse
  {
    [JilDirective(Name = "meta")] public Meta Meta { get; set; }

    [JilDirective(Name = "response")] public WebPageData Response { get; set; }
  }

  public class WebPageData
  {
    [JilDirective(Name = "web_page")] public WebPage WebPage { get; set; }
  }
}