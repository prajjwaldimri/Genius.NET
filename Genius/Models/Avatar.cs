namespace Genius.Models
{
    /// <summary>
    ///     Avatar of any user.
    /// </summary>
    public class Avatar
    {
        public Tiny Tiny { get; set; }
        public Thumb Thumb { get; set; }
        public Small Small { get; set; }
        public Medium Medium { get; set; }
    }

    /// <summary>
    ///     Tiny image of user profile
    /// </summary>
    public class Tiny
    {
        public string Url { get; set; }
        public BoundingBox BoundingBox { get; set; }
    }

    /// <summary>
    ///     Thumbnail of user profile image
    /// </summary>
    public class Thumb
    {
        public string Url { get; set; }
        public BoundingBox BoundingBox { get; set; }
    }

    /// <summary>
    ///     Small sized user profile image
    /// </summary>
    public class Small
    {
        public string Url { get; set; }
        public BoundingBox BoundingBox { get; set; }
    }

    /// <summary>
    ///     Medium sized user profile image.
    /// </summary>
    public class Medium
    {
        public string Url { get; set; }
        public BoundingBox BoundingBox { get; set; }
    }

    public class BoundingBox
    {
        public int width { get; set; }
        public int height { get; set; }
    }
}