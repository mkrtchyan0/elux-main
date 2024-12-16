using Elux.Application.Queries.User;
using Elux.Dal.Data;
using Elux.Domain.HelperClasses;
using Elux.Domain.Responses;
using Elux.Domain.Responses.User;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Elux.Application.Queries.User.Handlers
{
    /// <summary>
    /// Handler for the query to get all users with pagination.
    /// It retrieves users from the database and returns them in a paginated response format.
    /// </summary>
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, PaginatedResponse<PaginatedList<UserResponse>>>
    {
        private readonly ApplicationDbContext _context; // DbContext to access user data

        /// <summary>
        /// Initializes a new instance of the GetAllUsersQueryHandler with the provided ApplicationDbContext.
        /// </summary>
        /// <param name="context">ApplicationDbContext for accessing user data.</param>
        public GetAllUsersQueryHandler(ApplicationDbContext context)
        {
            _context = context; // Initialize the DbContext
        }

        /// <summary>
        /// Handles the GetAllUsersQuery request by retrieving all users from the database
        /// and returning them in a paginated format based on the requested page index and size.
        /// </summary>
        /// <param name="request">The GetAllUsersQuery containing the page index and page size for pagination.</param>
        /// <param name="cancellationToken">A token to cancel the operation if needed.</param>
        /// <returns>A PaginatedResponse containing the paginated list of users.</returns>
        public async Task<PaginatedResponse<PaginatedList<UserResponse>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            // Retrieve the users from the database and map them to UserResponse objects
            IEnumerable<UserResponse> users = await _context.Users.Select(x => new UserResponse
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                IsDeleted = x.IsDeleted,
                UserName = x.Email,
            })
                .ToListAsync(cancellationToken);

            // Create a PaginatedList to manage the subset of users based on page index and page size
            var paginatedUsers = new PaginatedList<UserResponse>(users, request.PageIndex, request.PageSize);

            // Check if users exist and return a PaginatedResponse with the user data
            if (users != null)
            {
                return new PaginatedResponse<PaginatedList<UserResponse>>(
                    paginatedUsers,
                    paginatedUsers.PageIndex,
                    paginatedUsers.PageSize,
                    paginatedUsers.TotalCount,
                    paginatedUsers.TotalPages);
            }

            // Return a failed response if no users are found
            return PaginatedResponse<PaginatedList<UserResponse>>.Failed();
        }
    }
}
