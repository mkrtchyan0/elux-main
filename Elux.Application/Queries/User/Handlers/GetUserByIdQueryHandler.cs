using Elux.Dal.Data;
using Elux.Domain.Entities;
using Elux.Domain.Responses;
using Elux.Domain.Responses.User;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Elux.Application.Queries.User.Handlers
{
    /// <summary>
    /// Handler for the query to get a user by their ID.
    /// It retrieves the user from the database, fetches their roles, and returns a user response.
    /// </summary>
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, BaseResponse<UserResponse>>
    {
        private readonly ApplicationDbContext _context; // DbContext to access user data
        private readonly UserManager<ApplicationUser> _userManager; // UserManager to interact with Identity

        /// <summary>
        /// Initializes a new instance of the GetUserByIdQueryHandler with the provided ApplicationDbContext and UserManager.
        /// </summary>
        /// <param name="context">ApplicationDbContext for accessing user data.</param>
        /// <param name="userManager">UserManager for interacting with the Identity system to get roles.</param>
        public GetUserByIdQueryHandler(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context; // Initialize the DbContext
            _userManager = userManager; // Initialize the UserManager
        }

        /// <summary>
        /// Handles the GetUserByIdQuery request by retrieving a user by their ID and returning their details in a UserResponse.
        /// If the user doesn't exist, a failed response is returned.
        /// </summary>
        /// <param name="request">The GetUserByIdQuery containing the user ID.</param>
        /// <param name="cancellationToken">A token to cancel the operation if needed.</param>
        /// <returns>A BaseResponse containing the user data or failure information.</returns>
        public async Task<BaseResponse<UserResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            // Retrieve the user from the database by their ID
            var user = _context.Users.FirstOrDefault(x => x.Id == request.Id);
            if (user == null)
            {
                // Return a failed response if the user is not found
                return BaseResponse<UserResponse>.Failed();
            }

            // Fetch the roles associated with the user using the UserManager
            var roles = await _userManager.GetRolesAsync(user);

            // Map the user data to a UserResponse object
            var result = new UserResponse
            {
                Id = request.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.Email, // Using email as the username
                Role = roles.FirstOrDefault(), // Only returning the first role (if exists)
            };

            // Return a successful response with the user data
            return BaseResponse<UserResponse>.Success(result);
        }
    }

    /// <summary>
    /// Validator for the GetUserByIdQuery. Ensures the user ID is provided and is not empty.
    /// </summary>
    public class GetUserByIdQueryValidator : AbstractValidator<GetUserByIdQuery>
    {
        public GetUserByIdQueryValidator()
        {
            // Validates that the user ID is not empty
            RuleFor(user => user.Id)
                .NotEmpty()
                .WithMessage("GUID is required.");
        }
    }
}
