using Elux.Application.Commands.Services;
using Elux.Application.Queries.Service;
using Elux.Domain.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Elux.Api.Controllers
{
    [ApiController]
    [Route("api")]
    [ApiExplorerSettings(GroupName = "Services")]
    public class ServiceController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        [Route("serivce/add")]
        public async Task<AppResponse> AddService(AddServiceCommand command, CancellationToken token)
        {
            return await mediator.Send(command, token);
        }
        [HttpGet]
        [Route("service")]
        public async Task<IActionResult> GetServiceById([FromQuery] Guid serviceId)
        {
            var query = await mediator.Send(new GetServiceByIdQuery() { Id = serviceId });

            return Ok(query);
        }
        [HttpGet]
        [Route("services")]
        public async Task<IActionResult> GetAllServices([FromQuery] string serviceGrouId, [FromQuery] int index = 1, [FromQuery] int size = 5)
        {
            var result = await mediator.Send(new GetAllServicesQuery() { ServiceGroupId = serviceGrouId, PageIndex = index, PageSize = size });

            return Ok(result);
        }
        [HttpPost]
        [Route("serivcegroup/add")]
        public async Task<AppResponse> AddServiceGroup(AddServiceGroupCommand command, CancellationToken token)
        {
            return await mediator.Send(command, token);
        }
        [HttpGet]
        [Route("serivcegroup/id")]
        public async Task<IActionResult> GetServiceGroupById([FromQuery] Guid ServiceGroupId)
        {
            var query = await mediator.Send(new GetServiceGroupById { Id = ServiceGroupId });

            return Ok(query);
        }
        [HttpGet]
        [Route("serivcegroup/all")]
        public async Task<IActionResult> GetAllServiceGroups(CancellationToken token)
        {
            var result = await mediator.Send(new GetAllServiceGroupsQuery(), token);
            if (result.Count == 0)
                return NotFound();
            return Ok(result);
        }
    }
}