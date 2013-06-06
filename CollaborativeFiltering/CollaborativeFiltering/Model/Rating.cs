
namespace CollaborativeFiltering.Model
{
    public class Rating
    {
        public int UserId { get; set; }
        public int ItemId { get; set; }
        public int Score { get; set; }
        public string Timestamp { get; set; }
    }
}
