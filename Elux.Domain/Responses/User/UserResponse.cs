namespace Elux.Domain.Responses.User
{
    /// <summary>
    /// Represents a response containing user details.
    /// </summary>
    public class UserResponse
    {
        /// <summary>
        /// Gets or sets the unique identifier of the user.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the role of the user (e.g., Admin, User).
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// Gets or sets the username of the user.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the first name of the user.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the user.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Indicates whether the user is marked as deleted.
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
