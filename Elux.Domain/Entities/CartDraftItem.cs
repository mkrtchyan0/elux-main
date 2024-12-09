namespace Elux.Domain.Entities
{
    public class CartDraftItem
    {
        public Guid Id { get; set; }
        public List<BookServiceItem> Services { get; set; }
        public decimal TotalPrice { get; set; }        
    }
}
