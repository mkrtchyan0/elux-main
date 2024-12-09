using Elux.Domain.Entities;
using Elux.Domain.Responses;
using MediatR;

namespace Elux.Application.Queries.Service
{
    public class GetServiceByIdQuery : IRequest<BaseResponse<ServiceGroup>>
    {
        public Guid Id { get; set; }
    }
}
