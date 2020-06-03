using System.Threading.Tasks;
using Genius.Models.Response;

namespace Genius.Clients.Interfaces
{
  /// <summary>
  /// Handles Web Page related queries
  /// </summary>
  public interface IWebPageClient
  {
    /// <summary>
    /// Information about a web page retrieved by the page's full URL (including protocol).
    /// The returned data includes Genius's ID for the page,
    /// which may be used to look up associated referents with the /referents endpoint.
    /// Data is only available for pages that already have at least one annotation.
    /// </summary>
    /// <param name="rawAnnotatableUrl">The URL as it would appear in a browser</param>
    /// <param name="canonicalUrl">The URL as specified by an appropriate &lt;link&gt; tag in a page's &lt;head&gt;</param>
    /// <param name="ogUrl">The URL as specified by an og:url &lt;meta&gt; tag in a page's &lt;head&gt;</param>
    /// <returns>A Web Page</returns>
    Task<WebPageResponse> GetWebPage(string rawAnnotatableUrl, string canonicalUrl = null, string ogUrl = null);
  }
}