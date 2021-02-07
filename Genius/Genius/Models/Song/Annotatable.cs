using Jil;
using System;
using System.Collections.Generic;
using System.Text;

namespace Genius.Models.Song
{
    public class Annotatable
    {
        [JilDirective("api_path")]
        public string ApiPath { get; set; }

        [JilDirective("client_timestamps")]
        public ClientTimestamps ClientTimestamps { get; set; }

        [JilDirective("context")]
        public string Context { get; set; }

        [JilDirective("id")]
        public ulong Id { get; set; }

        [JilDirective("image_url")]
        public string ImageUrl { get; set; }

        [JilDirective("link_title")]
        public string LinkTitle { get; set; }

        [JilDirective("title")]
        public string Title { get; set; }

        [JilDirective("type")]
        public string Type { get; set; }

        [JilDirective("url")]
        public string Url { get; set; }
    }
}
