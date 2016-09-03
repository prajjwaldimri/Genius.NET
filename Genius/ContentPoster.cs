using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genius
{
    public class ContentPoster
    {
        /// <summary>
        /// Many API requests accept a text_format query parameter that can be used to specify how text content is formatted.
        /// The value for the parameter must be one or more of plain, html, and dom. 
        /// The value returned will be an object with key-value pairs of formats and results:
        ///
        ///`plain` is just plain text, no markup
        ///`html` is a string of unescaped HTML suitable for rendering by a browser
        ///`dom` is a nested object representing and HTML DOM hierarchy that can be used to programmatically present structured content
        /// </summary>
        public static string TextFormat { get; set; }
    }
}
