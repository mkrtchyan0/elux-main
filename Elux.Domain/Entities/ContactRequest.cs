namespace Elux.Domain.Entities
{
    /// <summary>
    /// Represents a contact request entity.
    /// </summary>
    public class ContactRequest
    {
        /// <summary>
        /// Gets or sets the unique identifier for the contact request.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the full name of the person making the contact request.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Gets or sets the email address of the person making the contact request.
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the person making the contact request.
        /// </summary>
        public int PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the message content from the person making the contact request.
        /// </summary>
        public string YourMessage { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the contact request has been read.
        /// </summary>
        public bool IsRead { get; set; }
    }
}
