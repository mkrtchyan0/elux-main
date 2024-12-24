namespace Elux.Domain.Entities
{
    /// <summary>
    /// Represents a draft item in the cart, which includes a list of services and the total price.
    /// </summary>
    public class CartDraftItem
    {
        public Guid Id { get; set; }
        public List<BookServiceItemDraft> BookItems { get; set; }
        public decimal TotalPrice { get; set; }
    }
}