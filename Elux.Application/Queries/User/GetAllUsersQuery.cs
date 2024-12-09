using Elux.Domain.HelperClasses;
using Elux.Domain.Responses;
using Elux.Domain.Responses.User;
using MediatR;

namespace Elux.Application.Queries.User
{
    public class GetAllUsersQuery : IRequest<PaginatedResponse<PaginatedList<UserResponse>>>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }

}
