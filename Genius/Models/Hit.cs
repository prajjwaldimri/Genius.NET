namespace Genius.Models
{
    /// <summary>
    ///     Response from a search consist of an array of hits.
    /// </summary>
    public class Hit
    {
        public object[] Highlights { get; set; }
        public string Index { get; set; }
        public string Type { get; set; }
        public object Result { get; set; }
    }
}