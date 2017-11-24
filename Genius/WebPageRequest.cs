using Genius.Data;
using System;
using System.Threading.Tasks;

namespace Genius
{
	public class WebPageRequest : GeniusGetRequest
	{
		public WebPageRequest(string authorizationToken) : base("web_pages", authorizationToken)
		{
		}

		public async Task<WebPage> GetWebPagebyUrl(string rawAnnotableUrl, string canonicalUrl = "", string ogUrl = "")
		{
			if (string.IsNullOrEmpty(rawAnnotableUrl))
				throw new ArgumentException("Value cannot be null or empty.", nameof(rawAnnotableUrl));
			if (canonicalUrl == null)
				throw new ArgumentNullException(nameof(canonicalUrl));
			if (ogUrl == null)
				throw new ArgumentNullException(nameof(ogUrl));

			return await GetTask<WebPage>("web_page", $"lookup?raw_annotatable_url={rawAnnotableUrl}&canoncial_url={canonicalUrl}&og_url={ogUrl}");
		}
	}
}