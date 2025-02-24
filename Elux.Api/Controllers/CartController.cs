﻿using Elux.Application.Commands.Cart;
using Elux.Application.Commands.CartDraft;
using Elux.Application.Commands.Notification;
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
        [HttpPost("cart")]
        public async Task<AppResponse> AddCart([FromBody] CreateCartCommand command)
        {
            return await mediator.Send(command);
        }
        [HttpPost("sendnotification")]
        public async Task<bool> SendNotification([FromBody] SendNotificationCommand command)
        {
            return await mediator.Send(command);
        }
    }
}
