using Elux.Domain.Entities; // Importing the ApplicationExpert entity
using Elux.Domain.HelperClasses; // Importing PaginatedList and related helper classes
using Elux.Domain.Responses; // Importing PaginatedResponse class and BaseResponse class
using MediatR; // For implementing the CQRS pattern (Command Query Responsibility Segregation)

namespace Elux.Application.Queries.Expert
{
    /// <summary>
    /// Query to get a paginated list of experts.
    /// </summary>
    public class GetAllExpertsQuery : IRequest<PaginatedResponse<PaginatedList<ApplicationExpert>>>
    {
        /// <summary>
        /// The page index for pagination.
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// The page size for pagination.
        /// </summary>
        public int PageSize { get; set; }
    }
}
