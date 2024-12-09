using Azure;
using Elux.Domain.Entities;
using Elux.Domain.Responses;
using MediatR;

namespace Elux.Application.Commands.Services
{
    public class AddServiceGroupCommand : IRequest<BaseResponse<ServiceGroup>>
    {
        public string ServiceGroupName { get; set; }
        public string ServiceDescription { get; set; }
        public string Picture { get; set; }
    }
}
