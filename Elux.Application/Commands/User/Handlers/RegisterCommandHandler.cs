using Elux.Dal.Data;
using Elux.Domain.Entities;
using Elux.Domain.Responses;
using Elux.Domain.Responses.User;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Elux.Application.Commands.User.Handlers
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, BaseResponse<UserResponse>>
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;
        public RegisterCommandHandler(ApplicationDbContext context, UserManager<ApplicationUser> userManager,
                                      SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole<Guid>> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public async Task<BaseResponse<UserResponse>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user != null)
                return BaseResponse<UserResponse>.Failed("User with this email is already registered!");
            user = new ApplicationUser
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.Email,
                Email = request.Email,
                PasswordHash = request.Password
            };
            try
            {
                await _userManager.CreateAsync(user, request.Password);
            }
            catch (Exception)
            {
                return BaseResponse<UserResponse>.Failed();
            }
            var roleResult = await _roleManager.RoleExistsAsync("user");

            if (!roleResult)
                await _roleManager.CreateAsync(new IdentityRole<Guid>("user"));

            var addToRoleResult = await _userManager.AddToRoleAsync(user, "user");
            if (!addToRoleResult.Succeeded)
                return BaseResponse<UserResponse>.Failed();
            try
            {
                await _signInManager.SignInAsync(user, isPersistent: true);
            }
            catch (Exception)
            {
                return BaseResponse<UserResponse>.Failed();
            }
            return BaseResponse<UserResponse>.Success();
        }
    }
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            // Email validation
            RuleFor(user => user.Email)
                 .NotEmpty()
                 .WithMessage("Email is required.")
                 .EmailAddress()
                 .WithMessage("Please provide a valid email address.");

            // FirstName validation
                RuleFor(user => user.FirstName)
                .NotEmpty()
                .WithMessage("Username is required.")
                .MinimumLength(4)
                .WithMessage("Username must be at least 4 characters long.");

            // LastName validation
            RuleFor(user => user.LastName)
                .NotEmpty()
                .WithMessage("Username is required.")
                .MinimumLength(4)
                .WithMessage("Username must be at least 4 characters long.");

            // Password validation
            RuleFor(user => user.Password)
                .NotEmpty()
                .WithMessage("Password is required.")
                .MinimumLength(6)
                .WithMessage("Password must be at least 6 characters long.")
                .Matches(@"[A-Z]+").WithMessage("Password must contain at least one uppercase later.")
                .Matches(@"[a-z]+").WithMessage("Password must contain at least one lowercase later.")
                .Matches(@"[0-9]+").WithMessage("Password must contain at least one number.")
                .Matches(@"[\<\>\+\-\=\(\)\^\#\%\&\$\@\!\?\*\.]+").WithMessage("Password must contain at least one number.").WithMessage("Password must contain at least characters.");
        }
    }
}
