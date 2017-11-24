using System;

namespace Genius
{
	/// <summary>
	/// Authenticates the user with Genius using OAuth2.0
	/// </summary>
	public class Authenticator
	{
		public const string GENIUS_AUTHORIZATION_URL = GeniusRequest.GENIUS_API_URL + "authorize";

		public const string CODE_RESPONSE = "code";
		public const string TOKEN_RESPONSE = "token";

		/// <summary>
		/// Returns Authentication URL.
		/// Needs variables (ClientId, RedirectUri, Scope, State and ResponseType) set before calling!
		/// </summary>
		/// <param name="clientId">Your application's Client Secret, as listed on the API Client management page. ClientSecret can be found at https://genius.com/api-clients</param>
		/// <param name="redirectUri">The URI Genius will redirect the user to after they've authorized your application; it must be the same as the one set for the API client on the management page.
		/// This URL contains the `code` parameter as prefix and should be in the form of https://YOUR_REDIRECT_URI/?code=CODE&state=SOME_STATE_VALUE</param>
		/// <param name="scope">The permissions your application is requesting as a space-separated list. For more details goto https://docs.genius.com/#/available-scopes</param>
		/// <param name="state">A value that will be returned with the code redirect for maintaining arbitrary state through the authorization process</param>
		/// <returns>A URL that should be used to login and verify the user using any web-based client. 
		/// e.g. Use a Web Browser to navigate to this URL</returns>
		public static Uri GetAuthenticationUrl(string clientId, string redirectUri, string scope, string state)
		{
			return GetAuthenticationUrl(clientId, redirectUri, scope, state, CODE_RESPONSE);
		}

		/// <summary>
		/// An alternative authentication flow is available for browser-based, client-only applications. 
		/// This mechanism is much less secure than the full code exchange process and should only be used by applications without a server
		/// or native platform to execute the full code flow.
		/// 
		/// Instead of being redirected with a code that your application exchanges for an access token,
		///  the user is redirected to https://REDIRECT_URI/#access_token=ACCESS_TOKEN&state=STATE. 
		/// Extract the access token from the URL hash fragment and use it to make requests.
		/// </summary>
		/// <param name="clientId">Your application's Client Secret, as listed on the API Client management page. ClientSecret can be found at https://genius.com/api-clients</param>
		/// <param name="redirectUri">The URI Genius will redirect the user to after they've authorized your application; it must be the same as the one set for the API client on the management page.
		/// This URL contains the `code` parameter as prefix and should be in the form of https://YOUR_REDIRECT_URI/?code=CODE&state=SOME_STATE_VALUE</param>
		/// <param name="scope">The permissions your application is requesting as a space-separated list. For more details goto https://docs.genius.com/#/available-scopes</param>
		/// <param name="state">A value that will be returned with the code redirect for maintaining arbitrary state through the authorization process</param>
		public static Uri GetAuthenticationUrlClientOnly(string clientId, string redirectUri, string scope, string state)
		{
			return GetAuthenticationUrl(clientId, redirectUri, scope, state, TOKEN_RESPONSE);
		}

		private static Uri GetAuthenticationUrl(string clientId, string redirectUri, string scope, string state, string responseType)
		{
			if (string.IsNullOrEmpty(clientId))
				throw new ArgumentException("Value cannot be null or empty.", nameof(clientId));
			if (string.IsNullOrEmpty(redirectUri))
				throw new ArgumentException("Value cannot be null or empty.", nameof(redirectUri));
			if (string.IsNullOrEmpty(scope))
				throw new ArgumentException("Value cannot be null or empty.", nameof(scope));
			if (string.IsNullOrEmpty(state))
				throw new ArgumentException("Value cannot be null or empty.", nameof(state));

			var uriBuilder = new UriBuilder(GENIUS_AUTHORIZATION_URL)
			{
				Query = $"client_id={clientId}&redirect_uri={redirectUri}&scope={scope}&" +
						$"state={state}&response_type={responseType}"
			};

			return uriBuilder.Uri;
		}
	}
}
