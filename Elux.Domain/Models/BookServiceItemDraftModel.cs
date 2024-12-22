namespace Elux.Domain.Models
{
    public class BookServiceItemDraftModel
    {
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
    }
}
