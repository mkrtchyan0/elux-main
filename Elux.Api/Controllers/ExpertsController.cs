using Elux.Application.Commands.Expert;
using Elux.Application.Queries.Expert;
using Elux.Domain.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Elux.Api.Controllers
{
    [Route("api")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Expert")]
    public class ExpertsController(IMediator mediator) : ControllerBase
    {

        [HttpGet]
        [Route("expert")]
        public async Task<IActionResult> GetExpertById([FromQuery] Guid expertId, CancellationToken token)
        {
            var query = await mediator.Send(new GetExpertByIdQuery() { Id = expertId }, token);
            return Ok(query);
        }
        [HttpGet]
        [Route("experts")]
        public async Task<IActionResult> GetAllExperts([FromQuery] int index = 0, [FromQuery] int size = 5, CancellationToken token = default)
        {
            var result = await mediator.Send(new GetAllExpertsQuery() { PageIndex = index, PageSize = size }, token);
            return Ok(result);
        }
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddExpert(AddExpertCommand cmd, CancellationToken token)
        {
            var result = await mediator.Send(cmd, token);
            return Ok(result);
        }
        [HttpPost]
        [Route("delete")]
        public async Task<AppResponse> DeleteExpert([FromQuery] Guid expertId, CancellationToken token)
        {
            var command = await mediator.Send(new DeleteExpertCommand { Id = expertId}, token);
            return (command);
        }
        [HttpPost]
        [Route("booking/all")]
        public async Task<AppResponse> GetBookings([FromBody]ExpertBookingsQuery query, CancellationToken token)
        {
           return await mediator.Send(query, token);
        }
    }
}
