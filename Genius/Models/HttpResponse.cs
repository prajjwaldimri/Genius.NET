namespace Genius.Models
{
    /// <summary>
    ///     Generic Model of HttpResponse from Genius API
    ///     https://docs.genius.com/#/response-format-h1
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class HttpResponse<T>
    {
        /// <summary>
        ///     Meta contains status and message for http requests.
        /// </summary>
        public Meta Meta { get; set; }

        /// <summary>
        ///     The data that you requested for is contained in this field.
        ///     Note: This is not the top-level response field. Any GET method in this library will automatically
        ///     traverse to one level below the response field to get the actual object.
        /// </summary>
        public T Response { get; set; }
    }

    /// https://docs.genius.com/#/response-format-h1
    public enum TextFormat
    {
        /// Is just plain text, no markup
        Plain,

        /// is a string of unescaped HTML suitable for HTML browsers
        Html,

        /// is a nested object representing HTML DOM hierarchy.
        Dom
    }
}