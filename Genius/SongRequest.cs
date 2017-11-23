using Genius.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Genius
{
	public class SongRequest : GeniusGetRequest
	{
		public SongRequest(string authorizationToken) : base("", authorizationToken)
		{
		}

		/// <summary>
		/// Gets Data for a specific Song
		/// </summary>
		/// <param name="songId">Id of the song</param>
		/// <returns>A Song Object</returns>
		public async Task<Song> GetSongbyId(string songId)
		{
			if (string.IsNullOrEmpty(songId))
				throw new ArgumentException("Value cannot be null or empty.", nameof(songId));

			return await GetTask<Song>("song", $"songs/{songId}");
		}

		/// <summary>
		/// Documents (songs) for the artist specified. By default, 20 items are returned for each request.
		/// </summary>
		/// <param name="artistId">ID of the artist. </param>
		/// <param name="sort">	title (default) or popularity</param>
		/// <param name="perPage">Number of results to return per request</param>
		/// <param name="paginatedOffset">Paginated offset, (e.g., per_page=5&amp;page=3 returns songs 11–15)</param>
		/// <returns>List of Songs</returns>
		public async Task<List<Song>> GetSongsbyArtist(string artistId, string sort = "title", string perPage = "", string paginatedOffset = "")
		{
			if (string.IsNullOrEmpty(artistId))
				throw new ArgumentException("Value cannot be null or empty.", nameof(artistId));
			if (string.IsNullOrEmpty(sort))
				throw new ArgumentException("Value cannot be null or empty.", nameof(sort));
			if (perPage == null)
				throw new ArgumentNullException(nameof(perPage));
			if (paginatedOffset == null)
				throw new ArgumentNullException(nameof(paginatedOffset));

			return await GetTask<List<Song>>("songs", $"artists/{artistId}/songs");
		}
	}
}