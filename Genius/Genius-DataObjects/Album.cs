using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Genius
{
    public class Album
    {
        [JsonProperty(PropertyName = "api_path")]
        public string ApiPath { get; set; }

        [JsonProperty(PropertyName = "cover_art_url")]
        public string CoverArtUrl { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public Artist Artist { get; set; }
    }
}
