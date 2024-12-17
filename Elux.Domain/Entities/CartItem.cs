namespace Elux.Domain.Entities
{
    /// <summary>
    /// Represents an item in the shopping cart.
    /// </summary>
    public class CartItem
    {
        public Guid Id { get; set; }
        public Guid BookServiceItemId { get; set; }
        public int TotalPrice { get; set; }
        //public List<BookServiceItem> Services { get; set; }
    }
}
