namespace Genius.Models
{
    /// <summary>
    ///     A web page is a single, publicly accessible page to which annotations may be attached.
    ///     https://docs.genius.com/#!#web_pages-h2
    /// </summary>
    public class WebPage
    {
        public string Domain { get; set; }
        public string Id { get; set; }
        public string NormalizedUrl { get; set; }
        public string ShareUrl { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public int? AnnotationCount { get; set; }

        //Only in POST
        public string CanonicalUrl { get; set; }
        public string OgUrl { get; set; }
    }
}