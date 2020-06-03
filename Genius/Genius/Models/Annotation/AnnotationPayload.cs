using System;
using Genius.Models.Referent;
using Jil;

namespace Genius.Models.Annotation
{
  /// <summary>
  /// Required to create or update annotations.
  /// </summary>
  public class AnnotationPayload
  {
    [JilDirective(Name = "annotation")] public AnnotationBody Annotation;

    [JilDirective(Name = "referent")] public ReferentPayload Referent;

    [JilDirective(Name = "web_page")] public WebPagePayload WebPage;

    public AnnotationPayload(string markdown, ReferentPayload referentPayload, WebPagePayload webPagePayload)
    {
      Annotation = new AnnotationBody() {Body = new Body() {Markdown = markdown}};
      Referent = referentPayload;
      WebPage = webPagePayload;
    }


    public class Body
    {
      [JilDirective(Name = "markdown")] public string Markdown { get; set; }
    }

    public class AnnotationBody
    {
      [JilDirective(Name = "body")] public Body Body { get; set; }
    }
  }

  public class WebPagePayload
  {
    [JilDirective(Name = "canonical_url")] public string CanonicalUrl { get; set; }

    [JilDirective(Name = "og_url")] public string OgUrl { get; set; }

    [JilDirective(Name = "title")] public string Title { get; set; }

    /// <summary>
    /// At least one parameter is required.
    /// </summary>
    /// <param name="canonicalUrl"> The href property of the <link rel="canonical"/> tag on the page.
    /// Including it will help make sure newly created annotation appear on the correct page</param>
    /// <param name="ogUrl">The content property of the <meta property="og:url"/> tag on the page.
    /// Including it will help make sure newly created annotation appear on the correct page</param>
    /// <param name="title">The title of the page</param>
    /// <exception cref="ArgumentException"></exception>
    public WebPagePayload(string canonicalUrl = null, string ogUrl = null, string title = null)
    {
      if (string.IsNullOrWhiteSpace(canonicalUrl) && string.IsNullOrWhiteSpace(ogUrl) &&
          string.IsNullOrWhiteSpace(title))
      {
        throw new ArgumentException("At least one parameter is required");
      }

      CanonicalUrl = canonicalUrl;
      OgUrl = ogUrl;
      Title = title;
    }
  }
}