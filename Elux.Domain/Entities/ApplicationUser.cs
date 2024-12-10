using Microsoft.AspNetCore.Identity;

namespace Elux.Domain.Entities
{
    /// <summary>
    /// Represents an application user, extending the IdentityUser class.
    /// </summary>
    public class ApplicationUser : IdentityUser<Guid>
    {
        /// <summary>
        /// Gets or sets the first name of the user.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the user.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating whether the user is deleted.
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
