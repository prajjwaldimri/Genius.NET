using System.Collections.Generic;

namespace Genius.Data
{
	public class Contributor
    {
        public List<string> Contributions { get; set; }
        public Artist Artist { get; set; }
        public User User { get; set; }
    }
}
