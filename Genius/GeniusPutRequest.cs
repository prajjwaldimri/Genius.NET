using System;
using System.Threading.Tasks;

namespace Genius
{
	/// <summary>
	/// A genius request that only returns a task instead of an actually parsed response.
	/// </summary>
	public abstract class GeniusPutRequest : GeniusRequest
	{
		protected GeniusPutRequest(string baseRequestUrl, string authorizationToken) : base(baseRequestUrl, authorizationToken)
		{
		}

		/// <summary>
		/// Put to the previously defined url with a given additional data.
		/// </summary>
		protected virtual async Task Put(string addtionalUrl = "")
		{
			using (var client = CreateClient())
			{
				await client.PutAsync(CreateAddress(addtionalUrl), null).ConfigureAwait(false);
			}
		}

		/// <summary>
		/// Delete from the previously defined url with a given additional data.
		/// </summary>
		protected virtual async Task Delete(string addtionalUrl = "")
		{
			using (var client = CreateClient())
			{
				await client.DeleteAsync(CreateAddress(addtionalUrl)).ConfigureAwait(false);
			}
		}

		protected virtual Uri CreateAddress(string addtionalUrl)
		{
			return new Uri($"{BaseRequestUrl}{TrimSlashes(addtionalUrl)}");
		}
	}
}