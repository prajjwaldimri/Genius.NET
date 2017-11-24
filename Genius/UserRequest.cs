using Genius.Data;
using System.Threading.Tasks;

namespace Genius
{
	public class UserRequest : GeniusGetRequest
	{
		public UserRequest(string authorizationToken) : base("", authorizationToken)
		{
		}

		public async Task<User> GetAccountInfo()
		{
			return await GetTask<User>("user", "account");
		}
	}
}