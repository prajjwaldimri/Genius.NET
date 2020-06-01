using Newtonsoft.Json.Linq;

namespace Genius.Models
{
    /// <summary>
    ///     Response from a search consist of an array of hits.
    /// </summary>
    public class Hit
    {
        public JObject[] Highlights { get; set; }
        public string Index { get; set; }
        public string Type { get; set; }
        public JObject Result { get; set; }
    }
}