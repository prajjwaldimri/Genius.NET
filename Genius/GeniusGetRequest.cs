using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace Genius
{
	public abstract class GeniusGetRequest : GeniusRequest
	{
		protected GeniusGetRequest(string baseRequestUrl, string authorizationToken) : base(baseRequestUrl, authorizationToken)
		{
		}

		/// <summary>
		/// Get from the previously defined url with a given additional data.
		/// </summary>
		protected virtual async Task<string> GetString(string addtionalUrl = "")
		{
			using (var client = CreateClient())
			{
				var baseAddress = GetAddress(addtionalUrl);

				var response = await client.GetAsync(baseAddress).ConfigureAwait(false);
				using (var content = response.Content)
				{
					return await content.ReadAsStringAsync().ConfigureAwait(false);
				}
			}
		}

		/// <summary>
		/// Get from the previously defined url with a given additional data.
		/// </summary>
		protected virtual async Task<T> GetTask<T>(string token, string addtionalUrl = "") => ProcessContent<T>(await GetString(addtionalUrl), token);

		/// <summary>
		/// Parse the given <paramref name="content"/> to an actual task of the given gernic type.
		/// </summary>
		protected virtual T ProcessContent<T>(string content, string tokenString) => ProcessContent<T>(
			JToken.Parse(content), tokenString);

		/// <summary>
		/// Parse the given <paramref name="content"/> to an actual task of the given gernic type.
		/// </summary>
		protected virtual T ProcessContent<T>(JToken content, string tokenString)
		{
			var jsonReferents = content.SelectToken("response").SelectToken(tokenString);
			var deserializedObject = JsonConvert.DeserializeObject<T>(jsonReferents.ToString());

			return deserializedObject;
		}
	}
}