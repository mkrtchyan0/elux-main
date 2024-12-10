using Elux.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Elux.Application.Commands.User.Handlers
{
    /// <summary>
    /// This class handles the user logout logic.
    /// It signs the user out from the application using the SignInManager.
    /// </summary>
    public class LogoutCommandHandler : IRequestHandler<LogoutCommand>
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        /// <summary>
        /// Constructor to inject the SignInManager dependency.
        /// </summary>
        /// <param name="signInManager">SignInManager used to manage user sign-in/sign-out operations.</param>
        public LogoutCommandHandler(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        /// <summary>
        /// Handles the logout command by signing the user out.
        /// </summary>
        /// <param name="request">The logout command.</param>
        /// <param name="cancellationToken">Cancellation token to cancel the operation if necessary.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        async Task IRequestHandler<LogoutCommand>.Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            // Sign the user out
            await _signInManager.SignOutAsync();
        }
    }

}
