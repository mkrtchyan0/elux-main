namespace Elux.Domain.Entities
{
    /// <summary>
    /// Represents an item in the shopping cart.
    /// </summary>
    public class CartItem
    {
        /// <summary>
        /// Gets or sets the unique identifier for the cart item.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the list of services associated with the cart item.
        /// </summary>
        public Guid BookServiceItemId { get; set; }
        //public List<BookServiceItem> Services { get; set; }
        public int TotalPrice { get; set; }
    }
}
