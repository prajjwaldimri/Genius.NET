using Genius.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Genius
{
	public class SearchRequest : GeniusGetRequest
	{
		public SearchRequest(string authorizationToken) : base("", authorizationToken)
		{
		}

		public async Task<List<Hit>> Search(string searchTerm)
		{
			if (searchTerm == null) throw new ArgumentNullException(nameof(searchTerm));

			return await GetTask<List<Hit>>("hits", $"search?q={searchTerm}");
		}
	}

	public class Hit
	{
		public string Index { get; set; }
		public string type { get; set; }
		public Song Result { get; set; }
	}
}