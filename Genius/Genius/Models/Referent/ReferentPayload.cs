using Jil;

namespace Genius.Models.Referent
{
  /// <summary>
  /// Used when creating an Annotation
  /// </summary>
  public class ReferentPayload
  {
    [JilDirective(Name = "raw_annotatable_url")]
    public string RawAnnotatableUrl { get; set; }

    [JilDirective(Name = "fragment")] public string Fragment { get; set; }

    [JilDirective(Name = "context_for_display")]
    public ContextForDisplay ContextForDisplay { get; set; }

    /// <param name="rawAnnotatableUrl">The original URL of the page</param>
    /// <param name="fragment">The highlighted fragment</param>
    /// <param name="contextForDisplay">Html before and after fragment</param>
    public ReferentPayload(string rawAnnotatableUrl, string fragment,
      ContextForDisplay contextForDisplay = null)
    {
      RawAnnotatableUrl = rawAnnotatableUrl;
      Fragment = fragment;
      ContextForDisplay = contextForDisplay;
    }
  }

  public class ContextForDisplay
  {
    /// <summary>
    /// The HTML before the highlighted fragment (prefer up to 200 characters)
    /// </summary>
    [JilDirective(Name="before_html")]
    public string BeforeHtml { get; set; }
    
    /// <summary>
    /// The HTML after the highlighted fragment (prefer up to 200 characters)
    /// </summary>
    [JilDirective(Name="after_html")]
    public string AfterHtml { get; set; }

    public ContextForDisplay(string beforeHtml = "", string afterHtml = "")
    {
      BeforeHtml = beforeHtml;
      AfterHtml = afterHtml;
    }
  }
}