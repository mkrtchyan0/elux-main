using Elux.Domain.Responses.User; // Importing user-related responses
using MediatR; // Importing MediatR for request/handler pattern
using Microsoft.AspNetCore.Http; // Importing ASP.NET Core's HttpContext

namespace Elux.Application.Commands.User
{
    /// <summary>
    /// Represents a command to log in a user.
    /// </summary>
    public class LoginCommand : IRequest<(bool, string)>
    {
        /// <summary>
        /// The user's email address.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The user's password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// The HTTP context to manage session or cookies during login.
        /// </summary>
        public HttpContext HttpContext { get; set; }
    }
}
