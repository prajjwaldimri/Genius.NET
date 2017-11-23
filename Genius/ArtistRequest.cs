using Genius.Data;
using System;
using System.Threading.Tasks;

namespace Genius
{
	public class ArtistRequest : GeniusGetRequest
	{
		public ArtistRequest(string authorizationToken) : base("artists", authorizationToken)
		{
		}

		/// <summary>
		/// Data for a specific artist.
		/// </summary>
		/// <param name="artistId">ID of the artist </param>
		/// <returns>An Artist Object</returns>
		public async Task<Artist> GetArtistById(string artistId)
		{
			if (string.IsNullOrEmpty(artistId))
				throw new ArgumentException("Value cannot be null or empty.", nameof(artistId));

			return await GetTask<Artist>("artist", $"{artistId}");
		}
	}
}