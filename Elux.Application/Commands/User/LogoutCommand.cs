using MediatR; // Importing MediatR for request/handler pattern

namespace Elux.Application.Commands.User
{
    /// <summary>
    /// Represents a command to log out a user.
    /// </summary>
    public class LogoutCommand : IRequest
    {
        // No properties are needed for this command
    }
}
