using Elux.Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Elux.Application.Commands.User.Handlers
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, (bool, string)>
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public LoginCommandHandler(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public async Task<(bool, string)> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(request.Email);
                var result = await _signInManager.CanSignInAsync(user);
                if (result)
                {
                    string role;
                    var roles = await _userManager.GetRolesAsync(user);

                    if (roles != null)
                        role = roles.FirstOrDefault();
                    else role = "user";
                    var claims = new List<Claim>
                    {
                        new (ClaimTypes.Name, user.UserName),
                        new (ClaimTypes.Email, user.Email),
                        new (ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new (ClaimTypes.Role, "user"),
                        //new (ClaimTypes.Role, "admin")
                    };
                    var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = true,
                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(60)
                    };
                    await request.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                                                            new ClaimsPrincipal(claimsIdentity), authProperties);
                    return (true, "Success");
                }
                else
                    return (false, "Email or password is incorrect.");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
    }
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
                .Matches(@"[A-Za-z0-9]+")
                .WithMessage("Password must contain at least one letter and one number.");
        }
    }
}
