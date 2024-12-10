namespace Elux.Domain.Entities
{
    /// <summary>
    /// Represents a view model for a user, containing basic user information.
    /// </summary>
    public class UserView
    {
        /// <summary>
        /// Gets or sets the unique identifier of the user.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the username of the user.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the role name assigned to the user.
        /// </summary>
        public string RoleName { get; set; }
    }
}
