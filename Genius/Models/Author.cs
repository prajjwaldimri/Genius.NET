namespace Genius.Models
{
    public class Author
    {
        public string Attribution { get; set; }
        public string Pinned_Role { get; set; }
        public User User { get; set; }
    }
}
