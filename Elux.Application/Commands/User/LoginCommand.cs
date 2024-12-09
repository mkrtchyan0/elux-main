using Elux.Domain.Responses.User;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Elux.Application.Commands.User
{
    public class LoginCommand : IRequest<(bool, string)>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public HttpContext HttpContext { get; set; }
    }
}
