using Elux.Application.Commands.CartDraft;
using Elux.Domain.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Elux.Api.Controllers
{
    [Route("api/cart")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Cart")]
    public class CartController(IMediator mediator) : ControllerBase
    {
        [HttpPost("cartdraft")]
        public async Task<AppResponse> AddCartDraft([FromBody] CreateCartDraftCommand command)
        {
            return await mediator.Send(command);
        }
    }
}
