using System.Collections.Generic;

namespace Genius.Models
{
    /// <summary>
    ///     Contributors of a song.
    /// </summary>
    public class Contributor
    {
        public List<string> Contributions { get; set; }
        public Artist Artist { get; set; }
        public User User { get; set; }
    }
}