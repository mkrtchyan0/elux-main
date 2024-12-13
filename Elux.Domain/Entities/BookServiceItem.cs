namespace Elux.Domain.Entities
{
    /// <summary>
    /// Represents a service item that is part of a booking.
    /// </summary>
    public class BookServiceItem
    {
        /// <summary>
        /// Gets or sets the unique identifier for the service item.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the draft associated with the service item.
        /// </summary>
        public Guid CartDraftItemId { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the expert providing the service.
        /// </summary>
        public Guid ExpertId { get; set; }

        /// <summary>
        /// Gets or sets a list of identifiers for services associated with the service item.
        /// </summary>
        public Guid ServiceIds { get; set; }

        /// <summary>
        /// Gets or sets the total price of the service item.
        /// </summary>
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// Gets or sets the date when the service is scheduled.
        /// </summary>
        public DateTime ServiceDate { get; set; }

        /// <summary>
        /// Gets or sets the duration of the service in minutes.
        /// </summary>
        public int ServiceDuration { get; set; }
        public CartDraftItem CartDraftItem { get; set; }
    }
}
