using Elux.Domain.HelperClasses;
using Elux.Domain.Responses;
using Elux.Domain.Responses.User;
using MediatR;

namespace Elux.Application.Queries.User
{
    // The GetAllUsersQuery class represents a query to get all users in a paginated manner.
    // It implements MediatR's IRequest<T> interface, where T is the response type.
    public class GetAllUsersQuery : IRequest<PaginatedResponse<PaginatedList<UserResponse>>>
    {
        // PageIndex represents the current page number in pagination.
        public int PageIndex { get; set; }

        // PageSize represents how many users should be returned per page.
        public int PageSize { get; set; }
    }
}
