using Elux.Dal.Data;
using Elux.Domain.Entities;
using Elux.Domain.Responses;
using Elux.Domain.Responses.User;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Elux.Application.Commands.User.Handlers
{
    /// <summary>
    /// This class handles the user registration logic, including user creation, role assignment, and user sign-in.
    /// </summary>
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, BaseResponse<UserResponse>>
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;

        /// <summary>
        /// Constructor to inject dependencies into the handler.
        /// </summary>
        /// <param name="context">ApplicationDbContext to interact with the database.</param>
        /// <param name="userManager">UserManager to manage user operations.</param>
        /// <param name="signInManager">SignInManager to handle sign-in operations.</param>
        /// <param name="roleManager">RoleManager to handle role operations.</param>
        public RegisterCommandHandler(ApplicationDbContext context, UserManager<ApplicationUser> userManager,
                                      SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole<Guid>> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        /// <summary>
        /// Handles the user registration request.
        /// Validates the input, creates a new user, assigns a default role, and attempts to sign the user in.
        /// </summary>
        /// <param name="request">The registration command containing user details.</param>
        /// <param name="cancellationToken">Cancellation token for the task.</param>
        /// <returns>A response indicating success or failure of the registration process.</returns>
        public async Task<BaseResponse<UserResponse>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            // Check if user already exists based on the provided email
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user != null)
                return BaseResponse<UserResponse>.Failed("User with this email is already registered!");

            // Create a new user object
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
                // Attempt to create the user in the database
                await _userManager.CreateAsync(user, request.Password);
            }
            catch (Exception)
            {
                // Return failure if user creation fails
                return BaseResponse<UserResponse>.Failed();
            }

            // Check if the "user" role exists, and create it if necessary
            var roleResult = await _roleManager.RoleExistsAsync("user");
            if (!roleResult)
                await _roleManager.CreateAsync(new IdentityRole<Guid>("user"));

            // Assign the "user" role to the newly created user
            var addToRoleResult = await _userManager.AddToRoleAsync(user, "user");
            if (!addToRoleResult.Succeeded)
                return BaseResponse<UserResponse>.Failed();

            try
            {
                // Attempt to sign the user in after successful creation and role assignment
                await _signInManager.SignInAsync(user, isPersistent: true);
            }
            catch (Exception)
            {
                // Return failure if sign-in fails
                return BaseResponse<UserResponse>.Failed();
            }

            // Return success if the entire registration process is successful
            return BaseResponse<UserResponse>.Success();
        }
    }

    /// <summary>
    /// This class validates the user registration input before it is processed by the handler.
    /// </summary>
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        /// <summary>
        /// Constructor that sets up validation rules for the user registration command.
        /// </summary>
        public RegisterCommandValidator()
        {
            // Email validation: email must not be empty and must be a valid email address.
            RuleFor(user => user.Email)
                 .NotEmpty()
                 .WithMessage("Email is required.")
                 .EmailAddress()
                 .WithMessage("Please provide a valid email address.");

            // FirstName validation: first name must not be empty and must be at least 4 characters long.
            RuleFor(user => user.FirstName)
                .NotEmpty()
                .WithMessage("Username is required.")
                .MinimumLength(4)
                .WithMessage("Username must be at least 4 characters long.");

            // LastName validation: last name must not be empty and must be at least 4 characters long.
            RuleFor(user => user.LastName)
                .NotEmpty()
                .WithMessage("Username is required.")
                .MinimumLength(4)
                .WithMessage("Username must be at least 4 characters long.");

            // Password validation: password must meet certain criteria, including minimum length, containing uppercase, lowercase, numbers, and special characters.
            RuleFor(user => user.Password)
                .NotEmpty()
                .WithMessage("Password is required.")
                .MinimumLength(6)
                .WithMessage("Password must be at least 6 characters long.")
                .Matches(@"[A-Z]+").WithMessage("Password must contain at least one uppercase letter.")
                .Matches(@"[a-z]+").WithMessage("Password must contain at least one lowercase letter.")
                .Matches(@"[0-9]+").WithMessage("Password must contain at least one number.")
                .Matches(@"[\<\>\+\-\=\(\)\^\#\%\&\$\@\!\?\*\.]+").WithMessage("Password must contain at least one special character.");
        }
    }

}
