﻿namespace Elux.Domain.Entities
{
    /// <summary>
    /// Represents a draft item in the cart, which includes a list of services and the total price.
    /// </summary>
    public class CartDraftItem
    {
        /// <summary>
        /// Gets or sets the unique identifier for the cart draft item.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the list of services associated with this draft item.
        /// </summary>
        public List<BookServiceItem> Services { get; set; }

        /// <summary>
        /// Gets or sets the total price for all services in this draft item.
        /// </summary>
        public decimal TotalPrice { get; set; }
    }
}
