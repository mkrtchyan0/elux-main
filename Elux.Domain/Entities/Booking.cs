namespace Elux.Domain.Entities
{
    public class Booking
    {
        public Guid Id { get; set; }
        public Guid ExpertId { get; set; }
        public DateTime Day { get; set; }
        public DateTime StartingTime { get; set; }
        public DateTime EndingTime { get; set; }
    }
}
