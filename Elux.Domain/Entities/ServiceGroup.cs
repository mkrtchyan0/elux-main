namespace Elux.Domain.Entities
{
    /// <summary>
    /// Represents a group of services in the application.
    /// </summary>
    public class ServiceGroup
    {
        /// <summary>
        /// Gets or sets the unique identifier for the service group.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the service group.
        /// </summary>
        public string ServiceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the description of the service group.
        /// </summary>
        public string ServiceDescription { get; set; }

        /// <summary>
        /// Gets or sets the picture or image associated with the service group.
        /// </summary>
        public string Picture { get; set; }
    }
}
