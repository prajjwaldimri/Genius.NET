using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genius
{
    public class Author
    {
        public string Attribution { get; set; }
        public string Pinned_Role { get; set; }
        public User User { get; set; }
    }
}
