using Elux.Domain.Responses;
using Elux.Domain.Responses.User;
using MediatR;

namespace Elux.Application.Queries.User
{
    public class GetUserByIdQuery : IRequest<BaseResponse<UserResponse>>
    {
        public Guid Id { get; set; }
    }
}
