using System.Collections.Generic;

namespace Genius.Data
{
	/// <summary>
	/// A contributor to some event.
	/// </summary>
	public class Contributor
    {
		/// <summary>
		/// A list of all contributions.
		/// </summary>
        public List<string> Contributions { get; set; }
		/// <summary>
		/// The artist.
		/// </summary>
        public Artist Artist { get; set; }
		/// <summary>
		/// The user data this contributor has.
		/// </summary>
        public User User { get; set; }
    }
}
