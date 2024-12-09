using Elux.Dal.Data;
using Elux.Domain.Entities;
using Elux.Domain.HelperClasses;
using Elux.Domain.Responses;
using MediatR;

namespace Elux.Application.Queries.Service.Handlers
{
    public class GetAllServicesQueryHandler(ApplicationDbContext context) : IRequestHandler<GetAllServicesQuery, PaginatedResponse<PaginatedList<ServiceGroup>>>
    {
        public async Task<PaginatedResponse<PaginatedList<ServiceGroup>>> Handle(GetAllServicesQuery request, CancellationToken cancellationToken)
        {
            var services = context.ServiceGroups.ToList();

            if (services == null)
            {
                return PaginatedResponse<PaginatedList<ServiceGroup>>.Failed();
            }
            var paginatedList = new PaginatedList<ServiceGroup>(services, request.PageIndex, request.PageSize);

            return new PaginatedResponse<PaginatedList<ServiceGroup>>(
                paginatedList,
                paginatedList.PageIndex,
                paginatedList.PageSize,
                paginatedList.TotalCount,
                paginatedList.TotalPages);
        }
    }
}
