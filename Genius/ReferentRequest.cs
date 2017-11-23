using Genius.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Genius
{
	public class ReferentRequest : GeniusGetRequest
	{
		public ReferentRequest(string authorizationToken) : base("", authorizationToken)
		{
		}

		//TODO: Add Per-page and paginated offset
		/// <summary>
		/// Gets Referents using SongId Or UserId
		/// You may pass only one of song_id and web_page_id, not both.
		/// </summary>
		/// <param name="songId">ID of a song to get referents for</param>
		/// <param name="createdById">ID of a user to get referents for</param>
		/// <returns>A List of Referents</returns>
		public async Task<List<Referent>> GetReferentsbySongId(string songId, string createdById = "")
		{
			if (string.IsNullOrEmpty(songId))
				throw new ArgumentException("Value cannot be null or empty.", nameof(songId));
			if (string.IsNullOrEmpty(createdById))
				throw new ArgumentException("Value cannot be null or empty.", nameof(createdById));

			return await GetTask<List<Referent>>("referents", $"referents?song_id={songId}&created_by_id={createdById}");
		}

		/// <summary>
		/// Gets Referents using WebPageId or UserId
		/// You may pass only one of song_id and web_page_id, not both.
		/// </summary>
		/// <param name="webPageId">ID of a web page to get referents for</param>
		/// <param name="createdById">ID of a user to get referents for</param>
		/// <returns>A List of Referents</returns>
		public async Task<List<Referent>> GetReferentsbyWebPageId(string webPageId, string createdById = "")
		{
			if (string.IsNullOrEmpty(webPageId))
				throw new ArgumentException("Value cannot be null or empty.", nameof(webPageId));
			if (string.IsNullOrEmpty(createdById))
				throw new ArgumentException("Value cannot be null or empty.", nameof(createdById));

			return await GetTask<List<Referent>>("referents", $"referents?created_by_id={createdById}&web_page_id={webPageId}");
		}
	}
}