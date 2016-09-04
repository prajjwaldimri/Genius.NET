using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genius
{
    public class Contributor
    {
        public List<string> Contributions { get; set; }
        public Artist Artist { get; set; }
        public User User { get; set; }
    }
}
