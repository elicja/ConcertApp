namespace DataAccess
{
    public class ConcertData
    {
        public Guid Id { get; set; }
        public string ArtistName { get; set; }
        public double Price { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
    }
}
