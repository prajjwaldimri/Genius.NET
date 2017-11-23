using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Genius
{
	/// <summary>
	/// A request to the genius api (https://api.genius.com/). Normally a <see cref="GeniusPutRequest"/>
	/// or <see cref="GeniusGetRequest"/> is used.
	/// </summary>
	public abstract class GeniusRequest
	{
		protected readonly string AuthorizationToken;

		protected readonly string BaseRequestUrl;

		/// <summary>
		/// The base url for the Genius API. This string ends with a slash.
		/// </summary>
		public const string GENIUS_API_URL = "https://api.genius.com/";

		protected GeniusRequest(string baseRequestUrl)
		{
			if (baseRequestUrl == null) throw new ArgumentNullException(nameof(baseRequestUrl));

			baseRequestUrl = TrimSlashes(baseRequestUrl);

			if (baseRequestUrl.Length > 0)
			{
				BaseRequestUrl = GENIUS_API_URL + baseRequestUrl + "/";
			}
			else
			{
				BaseRequestUrl = GENIUS_API_URL;
			}
		}

		protected GeniusRequest(string baseRequestUrl, string authorizationToken) : this(baseRequestUrl)
		{
			if (string.IsNullOrEmpty(authorizationToken)) throw new ArgumentNullException(nameof(authorizationToken));
			AuthorizationToken = authorizationToken;
		}

		protected string TrimSlashes(string str)
		{
			if (str.StartsWith("/"))
			{
				str = str.Substring(1, str.Length - 1);
			}

			if (str.EndsWith("/"))
			{
				str = str.Substring(0, str.Length - 1);
			}

			return str;
		}

		protected virtual Uri GetAddress(string addtionalUrl)
		{
			return new Uri($"{BaseRequestUrl}{TrimSlashes(addtionalUrl)}");
		}

		protected virtual HttpClient CreateClient()
		{
			var client = new HttpClient();

			client.DefaultRequestHeaders.Clear();
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			if (AuthorizationToken != null)
			{
				client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthorizationToken);
			}

			return client;
		}
	}
}