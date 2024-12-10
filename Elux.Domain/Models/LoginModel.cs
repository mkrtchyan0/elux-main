namespace Elux.Domain.Models
{
    /// <summary>
    /// Represents the model for user login.
    /// </summary>
    public class LoginModel
    {
        /// <summary>
        /// Gets or sets the email address of the user.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the password of the user.
        /// </summary>
        public string Password { get; set; }
    }
}
