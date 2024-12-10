using Elux.Domain.Responses;
using Elux.Domain.Responses.User;
using MediatR;

namespace Elux.Application.Queries.User
{
    // The GetUserByIdQuery class represents a query to get a user by their unique ID.
    // It implements MediatR's IRequest<T> interface where T is the response type.
    public class GetUserByIdQuery : IRequest<BaseResponse<UserResponse>>
    {
        // Property to store the user's ID, which is passed as part of the query.
        public Guid Id { get; set; }
    }
}
