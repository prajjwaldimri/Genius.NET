namespace Genius.Models
{
    /// <summary>
    ///     Media items associated with a song.
    /// </summary>
    public class Media
    {
        public bool? Cinema { get; set; }
        public string Provider { get; set; }
        public int? Start { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
    }
}