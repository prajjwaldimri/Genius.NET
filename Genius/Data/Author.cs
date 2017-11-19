namespace Genius.Data
{
	/// <summary>
	/// An author of a post.
	/// </summary>
	public class Author
    {
		/// <summary>
		/// The attribution.
		/// </summary>
        public string Attribution { get; set; }
		/// <summary>
		/// The pinned role of the author.
		/// </summary>
        public string Pinned_Role { get; set; }
		/// <summary>
		/// The user info for this author.
		/// </summary>
        public User User { get; set; }
    }
}
