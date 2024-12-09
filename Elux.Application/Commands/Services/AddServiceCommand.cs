using Elux.Domain.Entities;
using Elux.Domain.Responses;
using MediatR;

namespace Elux.Application.Commands.Services
{
    public class AddServiceCommand : IRequest<BaseResponse<Service>>
    {
        public Guid ServiceGroupId { get; set; }
        public string ServiceName { get; set; }
        public int Duration { get; set; }
        public int Price { get; set; }
    }
}
