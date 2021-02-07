using Jil;
using System;
using System.Collections.Generic;
using System.Text;

namespace Genius.Models.Song
{
    public class Description
    {
        [JilDirective("html")]
        public string Html { get; set; }
    }
}
