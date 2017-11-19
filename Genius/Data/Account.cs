namespace Genius.Data
{
    /// <summary>
    /// Account information includes general contact information and Genius-specific details about a user.
    /// </summary>
    public class Account
    {
		/// <summary>
		/// The user belonging to this account.
		/// </summary>
        public User User { get; set; }
    }
}
