namespace Genius.Data
{
	public class Avatar
    {
        public Tiny Tiny { get; set; }
        public Thumb Thumb { get; set; }
        public Small Small { get; set; }
        public Medium Medium { get; set; }
    }

    public class Tiny
    {
        public string Url { get; set; }
        public BoundingBox BoundingBox { get; set; }
    }

    public class Thumb
    {
        public string Url { get; set; }
        public BoundingBox BoundingBox { get; set; }
    }

    public class Small
    {
        public string Url { get; set; }
        public BoundingBox BoundingBox { get; set; }
    }

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
