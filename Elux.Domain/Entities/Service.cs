using System.ComponentModel.DataAnnotations;

namespace Elux.Domain.Entities
{
    /// <summary>
    /// Represents a service offered in the application.
    /// </summary>
    public class Service
    {
        /// <summary>
        /// Gets or sets the unique identifier for the service.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the group to which the service belongs.
        /// </summary>
        public Guid GroupId { get; set; }

        /// <summary>
        /// Gets or sets the name of the service.
        /// </summary>
        public string ServiceName { get; set; }

        /// <summary>
        /// Gets or sets the duration of the service in minutes.
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        /// Gets or sets the price of the service in the local currency.
        /// </summary>
        public int Price { get; set; }
    }
}
