using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Genius
{
    /// <summary>
    /// Authenticates the user with Genius using OAuth2.0
    /// </summary>
    public class Authenticator
    {

        //Variables needed to Get Access Token. For more details go to https://docs.genius.com/#/authentication-h1
        //Should be set by developer before calling any methods!

        /// <summary>
        /// Your application's Client ID, as listed on the API Client management page. ClientId can be found at https://genius.com/api-clients
        /// </summary>
        public static string ClientId { private get; set; }
        /// <summary>
        /// Your application's Client Secret, as listed on the API Client management page. ClientSecret can be found at https://genius.com/api-clients
        /// </summary>
        public static string ClientSecret { private get; set; }
        ///<summary>
        ///The URI Genius will redirect the user to after they've authorized your application; it must be the same as the one set for the API client on the management page.
        /// This URL contains the `code` parameter as prefix and should be in the form of https://YOUR_REDIRECT_URI/?code=CODE&state=SOME_STATE_VALUE
        /// </summary>
        public static string RedirectUri { private get; set; }
        /// <summary>
        ///The permissions your application is requesting as a space-separated list. For more details goto https://docs.genius.com/#/available-scopes
        /// </summary>
        public static string Scope { private get; set; }
        /// <summary>
        ///  A value that will be returned with the code redirect for maintaining arbitrary state through the authorization process
        /// </summary>
        public static string State { private get; set; }

        //Should always be set to "code" as defined in Genius API docs
        private static string _responseType = "code";

        private const string GrantType = "authorization_code";


        /// <summary>
        /// Returns Authentication URL.
        /// Needs variables (ClientId, RedirectUri, Scope, State and ResponseType) set before calling!
        /// </summary>
        /// <returns>A URL that should be used to login and verify the user using any web-based client. 
        /// e.g. Use a Web Browser to navigate to this URL</returns>
        public static Uri GetAuthenticationUrl()
        {
            var uriBuilder = new UriBuilder("https://api.genius.com/oauth/authorize");

            if ((ClientId ?? RedirectUri ?? Scope ?? State) == null)
            {
                //TODO: Throw different exception for every parameter.
                throw new ArgumentNullException(ClientId, "Required Parameters cannot be null");
            }
            var queryToAppend = $"client_id={ClientId}&redirect_uri={RedirectUri}&scope={Scope}&" +
                                $"state={State}&response_type={_responseType}";
            uriBuilder.Query = queryToAppend;
            return uriBuilder.Uri;
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
        /// <returns></returns>
        public static Uri GetAuthenticationUrlClientOnly()
        {
            _responseType = "token";
            var uriBuilder = new UriBuilder("https://api.genius.com/oauth/authorize");

            if ((ClientId ?? RedirectUri ?? Scope ?? State) == null)
            {
                //TODO: Throw different exception for every parameter.
                throw new ArgumentNullException(ClientId, "Required Parameters cannot be null");
            }
            var queryToAppend = $"client_id={ClientId}&redirect_uri={RedirectUri}&scope={Scope}&" +
                                $"state={State}&response_type={_responseType}";
            uriBuilder.Query = queryToAppend;
            _responseType = "code";
            return uriBuilder.Uri;
        }

        /// <summary>
        /// Returns OAuth Access Access Token 
        /// </summary>
        /// <param name="redirectedUri">On the authentication page the user can choose to allow the application to access Genius on their behalf. 
        /// They'll be asked to sign in (or, if necessary, create an account) first. 
        /// Then the user is redirected to https://YOUR_REDIRECT_URI/?code=CODE&amp;state=SOME_STATE_VALUE</param>
        /// You have to retrieve this URL from your browsing client. 
        /// <returns>Access Token</returns>
        public static async Task<string> GetAccessToken(Uri redirectedUri)
        {
            //Url should be in the below format.
            //https://YOUR_REDIRECT_URI/?code=CODE&state=SOME_STATE_VALUE.

            if (redirectedUri.ToString().Contains("code="))
            {
                var query = redirectedUri.Query;
                var queryParameters = GetParams(query);
                using (var client = new HttpClient())
                {
                    const string baseAddress = "https://api.genius.com/oauth/token";
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var arb = new AuthenticationRequestBody
                    {
                        code = queryParameters["code"],
                        client_id = ClientId,
                        client_secret = ClientSecret,
                        redirect_uri = RedirectUri,
                        response_type = _responseType,
                        grant_type = "authorization_code"
                    };

                    var requestBody = JsonConvert.SerializeObject(arb);
                    var response =
                        await
                            client.PostAsync(baseAddress,
                                new StringContent(requestBody, Encoding.UTF8, "application/json")).ConfigureAwait(false);
                    response.EnsureSuccessStatusCode();
                    var accesstoken = await response.Content.ReadAsStringAsync();
                    var access = JsonConvert.DeserializeObject<AccessToken>(accesstoken);
                    return access.access_token;
                }
            }
            else
            {
                throw new ArgumentException("Wrong format of the provided Url", nameof(redirectedUri));
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
