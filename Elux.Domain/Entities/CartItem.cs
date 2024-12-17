namespace Elux.Domain.Entities
{
    /// <summary>
    /// Represents an item in the shopping cart.
    /// </summary>
    public class CartItem
    {
        public Guid Id { get; set; }
        public decimal TotalPrice { get; set; }        
    }
}
