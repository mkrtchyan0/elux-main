using Elux.Domain.Entities;
using Elux.Domain.HelperClasses;
using Elux.Domain.Responses;
using MediatR;

namespace Elux.Application.Queries.Expert
{
    public class GetAllExpertsQuery : IRequest<PaginatedResponse<PaginatedList<ApplicationExpert>>>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
