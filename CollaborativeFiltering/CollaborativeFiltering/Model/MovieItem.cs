
namespace CollaborativeFiltering.Model
{
    public class MovieItem 
    {
        public int ItemId { get; set; }
        public string MovieTitle { get; set; }
        public string ReleaseDate { get; set; }
        public string VideoReleaseDate { get; set; }
        public string IMDbUrl { get; set; }
        public double[] Genres { get; set; }

    }
}
