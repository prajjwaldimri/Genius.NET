namespace Genius.Models
{
    /// <summary>
    ///     Every JSON response from Genius API has a meta field which shows HTTP status code and
    ///     message field with error.
    /// </summary>
    public class Meta
    {
        public string Status { get; set; }
        public string Message { get; set; }
    }
}