namespace Elux.Domain.Entities
{
    public class CartItem
    {
        public Guid Id { get; set; }
        public List<BookServiceItem> Services { get; set; }
    }
}
