using Elux.Application.Queries.User;
using Elux.Dal.Data;
using Elux.Domain.HelperClasses;
using Elux.Domain.Responses;
using Elux.Domain.Responses.User;
using MediatR;

namespace Elux.Application.Queries.User.Handlers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, PaginatedResponse<PaginatedList<UserResponse>>>
    {
        private readonly ApplicationDbContext _context;
        public GetAllUsersQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<PaginatedResponse<PaginatedList<UserResponse>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<UserResponse> users = _context.Users.Select(x => new UserResponse
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                IsDeleted = x.IsDeleted,
                UserName = x.Email,
            });
            var paginatedUsers = new PaginatedList<UserResponse>(users, request.PageIndex, request.PageSize);
            if (users != null)
            {
                return new PaginatedResponse<PaginatedList<UserResponse>>(
                    paginatedUsers,
                    paginatedUsers.PageIndex,
                    paginatedUsers.PageSize,
                    paginatedUsers.TotalCount,
                    paginatedUsers.TotalPages);
            }
            return PaginatedResponse<PaginatedList<UserResponse>>.Failed();
        }
    }
}
