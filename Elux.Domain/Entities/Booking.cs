namespace Elux.Domain.Entities
{
    public class Booking
    {
        public Guid Id { get; set; }
        public Guid ExpertId { get; set; }
        public Guid ServiceId { get; set; }
        public DateOnly Date { get; set; } 
        public TimeOnly Start { get; set; }
        public TimeOnly End { get; set; }
    }
}
