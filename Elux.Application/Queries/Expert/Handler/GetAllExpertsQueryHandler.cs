using Elux.Dal.Data;
using Elux.Domain.Entities;
using Elux.Domain.HelperClasses;
using Elux.Domain.Responses;
using MediatR;

namespace Elux.Application.Queries.Expert.Handler
{
    public class GetAllExpertsQueryHandler(ApplicationDbContext context) : IRequestHandler<GetAllExpertsQuery, PaginatedResponse<PaginatedList<ApplicationExpert>>>
    {
        public async Task<PaginatedResponse<PaginatedList<ApplicationExpert>>> Handle(GetAllExpertsQuery request, CancellationToken cancellationToken)
        {
            var experts = context.Experts.ToList();

            if (experts == null)
            {
                return PaginatedResponse<PaginatedList<ApplicationExpert>>.Failed();
            }
            var paginatedList = new PaginatedList<ApplicationExpert>(experts, request.PageIndex, request.PageSize);

            return new PaginatedResponse<PaginatedList<ApplicationExpert>>(
                paginatedList,
                paginatedList.PageIndex,
                paginatedList.PageSize,
                paginatedList.TotalCount,
                paginatedList.TotalPages);
        }
    }
}
