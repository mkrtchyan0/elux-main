using Elux.Application.Commands.User;
using Elux.Application.Queries.User;
using Elux.Dal.Data;
using Elux.Domain.Entities;
using Elux.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Elux.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "Account")]
    public class AccountController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> RegisterAsync(RegisterCommand command)
        {
            var result = await mediator.Send(command);
            if (!result.Succeeded)
                return BadRequest(result.Message);
            return Ok(result.Data);
        }
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> LoginAsync(LoginModel model)
        {
            LoginCommand command = new()
            {
                HttpContext = HttpContext,
                Email = model.Email,
                Password = model.Password,
            };

            var (Success, Message) = await mediator.Send(command);
            if (Success)
                return Ok("Signed in");
            else
                return BadRequest(Message);
        }
        [HttpPost]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await mediator.Send(new LogoutCommand());
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        [Route("getby{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var user = await mediator.Send(new GetUserByIdQuery { Id = id });
            if (user.Succeeded)
            {
                return Ok(user);
            }
            return BadRequest();
        }
        [HttpGet]
        [Route("getall/{index}/{size}")]
        public async Task<IActionResult> GetAllUsers(int index = 0, int size = 10)
        {
            var result = await mediator.Send(new GetAllUsersQuery() { PageIndex = index, PageSize = size });

            return Ok(result);
        }
    }
}