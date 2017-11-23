using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Genius
{
	public class AuthenticationRequest : GeniusRequest
	{
		public string ClientId { get; set; }
		public string ClientSecret { get; set; }

		public AuthenticationRequest(string clientId, string clientSecret) : base("oauth/token")
		{
			if (string.IsNullOrEmpty(clientId))
				throw new ArgumentException("Value cannot be null or empty.", nameof(clientId));
			if (string.IsNullOrEmpty(clientSecret))
				throw new ArgumentException("Value cannot be null or empty.", nameof(clientSecret));

			ClientId = clientId;
			ClientSecret = clientSecret;
		}

		/// <summary>
		/// Returns OAuth Access Access Token 
		/// </summary>
		/// <param name="redirectedUri">On the authentication page the user can choose to allow the application to access Genius on their behalf. 
		/// They'll be asked to sign in (or, if necessary, create an account) first. 
		/// Then the user is redirected to https://YOUR_REDIRECT_URI/?code=CODE&amp;state=SOME_STATE_VALUE</param>
		/// You have to retrieve this URL from your browsing client. 
		/// <returns>Access Token</returns>
		public async Task<string> GetAccessToken(Uri redirectedUri)
		{
			//Url should be in the below format.
			//https://YOUR_REDIRECT_URI/?code=CODE&state=SOME_STATE_VALUE.

			var redirectUrl = redirectedUri.ToString();
			if (!redirectUrl.Contains("code="))
				throw new ArgumentException("Wrong format of the provided Url", nameof(redirectedUri));

			var query = redirectedUri.Query;
			var queryParameters = GetParams(query);
			using (var client = CreateClient())
			{
				var arb = new AuthenticationRequestBody
				{
					code = queryParameters["code"],
					client_id = ClientId,
					client_secret = ClientSecret,
					redirect_uri = redirectUrl,
					response_type = Authenticator.CODE_RESPONSE,
					grant_type = "authorization_code"
				};

				var requestBody = JsonConvert.SerializeObject(arb);
				var response =
					await
						client.PostAsync(BaseRequestUrl,
							new StringContent(requestBody, Encoding.UTF8, "application/json")).ConfigureAwait(false);
				response.EnsureSuccessStatusCode();
				var accesstoken = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
				var access = JsonConvert.DeserializeObject<AccessToken>(accesstoken);
				return access.access_token;
			}
		}

		/// <summary>
		/// Returns query parameters as Dictionary
		/// </summary>
		/// <param name="uri">Query Url</param>
		/// <returns></returns>
		private static Dictionary<string, string> GetParams(string uri)
		{
			var matches = Regex.Matches(uri, @"[\?&](([^&=]+)=([^&=#]*))", RegexOptions.None);
			var keyValues = new Dictionary<string, string>(matches.Count);
			foreach (Match m in matches)
				keyValues.Add(Uri.UnescapeDataString(m.Groups[2].Value), Uri.UnescapeDataString(m.Groups[3].Value));
			return keyValues;

		}

		internal class AuthenticationRequestBody
		{
			public string code;
			public string client_id;
			public string client_secret;
			public string redirect_uri;
			public string response_type;
			public string grant_type;
		}

		internal abstract class AccessToken
		{
			public string access_token;
		}
	}
}