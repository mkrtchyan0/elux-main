using Elux.Domain.Entities;
using Elux.Domain.HelperClasses;
using Elux.Domain.Responses;
using MediatR;

namespace Elux.Application.Queries.Service
{
    public class GetAllServicesQuery : IRequest<PaginatedResponse<PaginatedList<ServiceGroup>>>
    {
        public string ServiceGroupId { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
