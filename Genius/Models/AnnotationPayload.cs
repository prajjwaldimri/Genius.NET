namespace Genius.Models
{
    /// <summary>
    ///     Used when creating a new annotation or updating an old one. Contains necessary data about annotation.
    ///     https://docs.genius.com/#annotations-h2
    /// </summary>
    public class AnnotationPayload
    {
        /// https://docs.genius.com/#!#annotations-h2
        public Annotation Annotation;

        /// https://docs.genius.com/#!#referents-h2
        public Referent Referent;

        /// https://docs.genius.com/#!#web_pages-h2
        public WebPage WebPage;
    }
}