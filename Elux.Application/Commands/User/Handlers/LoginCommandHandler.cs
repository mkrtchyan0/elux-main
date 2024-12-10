using Elux.Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Elux.Application.Commands.User.Handlers
{
    /// <summary>
    /// This class handles the login logic, which involves verifying user credentials,
    /// assigning roles, and signing the user in using cookies for authentication.
    /// </summary>
    public class LoginCommandHandler : IRequestHandler<LoginCommand, (bool, string)>
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        /// <summary>
        /// Constructor to inject the required services: SignInManager and UserManager.
        /// </summary>
        /// <param name="signInManager">SignInManager used for signing the user in.</param>
        /// <param name="userManager">UserManager used to manage user accounts.</param>
        public LoginCommandHandler(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        /// <summary>
        /// Handles the login request by verifying the user's credentials and signing them in.
        /// </summary>
        /// <param name="request">The login command with user credentials.</param>
        /// <param name="cancellationToken">Token to monitor for cancellation requests.</param>
        /// <returns>A tuple containing a success flag and a message indicating the result.</returns>
        public async Task<(bool, string)> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Find the user by their email address
                var user = await _userManager.FindByEmailAsync(request.Email);
                if (user == null)
                    return (false, "User not found.");

                // Check if the user can sign in (e.g., account is not locked, etc.)
                var result = await _signInManager.CanSignInAsync(user);
                if (!result)
                    return (false, "Email or password is incorrect.");

                // Assign the role (use first role or default to 'user')
                string role;
                var roles = await _userManager.GetRolesAsync(user);
                role = roles?.FirstOrDefault() ?? "user";

                // Create a list of claims that will be used for authentication
                var claims = new List<Claim>
            {
                new (ClaimTypes.Name, user.UserName),
                new (ClaimTypes.Email, user.Email),
                new (ClaimTypes.NameIdentifier, user.Id.ToString()),
                new (ClaimTypes.Role, role),
            };

                // Create a ClaimsIdentity for the user
                var claimsIdentity = new ClaimsIdentity(claims, "Cookies");

                // Set authentication properties (persistent login, expiration time)
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(60)
                };

                // Sign the user in using cookies for authentication
                await request.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                                                        new ClaimsPrincipal(claimsIdentity), authProperties);

                return (true, "Success");
            }
            catch (Exception ex)
            {
                // Return failure with exception message
                return (false, ex.Message);
            }
        }
    }

    /// <summary>
    /// This class validates the login command input, ensuring the email and password meet the necessary criteria.
    /// </summary>
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            // Email validation
            RuleFor(user => user.Email)
                .NotEmpty()
                .WithMessage("Email is required.")
                .EmailAddress()
                .WithMessage("Please provide a valid email address.");

            // Password validation
            RuleFor(user => user.Password)
                .NotEmpty()
                .WithMessage("Password is required.")
                .MinimumLength(6)
                .WithMessage("Password must be at least 6 characters long.")
                .Matches(@"[A-Za-z0-9]+")  // Ensure password contains at least one letter and one number
                .WithMessage("Password must contain at least one letter and one number.");
        }
    }

}
