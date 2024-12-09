using Elux.Domain.Responses;
using Elux.Domain.Responses.User;
using MediatR;

namespace Elux.Application.Commands.User
{
    public class RegisterCommand : IRequest<BaseResponse<UserResponse>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}