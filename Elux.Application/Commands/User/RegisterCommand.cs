using Elux.Domain.Responses; // Importing BaseResponse to structure responses
using Elux.Domain.Responses.User; // Importing UserResponse for user-related response
using MediatR; // Importing MediatR for request/handler pattern

namespace Elux.Application.Commands.User
{
    /// <summary>
    /// Represents a command to register a user.
    /// </summary>
    public class RegisterCommand : IRequest<BaseResponse<UserResponse>>
    {
        // Properties required for user registration
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
