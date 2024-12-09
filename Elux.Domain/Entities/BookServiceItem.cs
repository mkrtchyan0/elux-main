namespace Elux.Domain.Entities
{
    public class BookServiceItem
    {
        public Guid Id { get; set; }
        public Guid DraftId { get; set; }
        public Guid ExpertsId { get; set; }
        public List<Guid> SubServiceId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime ServiceDate { get; set; }
        public int ServiceDuration { get; set; }
    }
}
