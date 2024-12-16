using Elux.Dal.Data; // Importing the ApplicationDbContext class to interact with the database
using Elux.Domain.Entities; // Importing the ApplicationExpert entity class
using Elux.Domain.HelperClasses; // Importing PaginatedList for pagination functionality
using Elux.Domain.Responses; // Importing PaginatedResponse for structured response
using MediatR;
using Microsoft.EntityFrameworkCore; // Importing MediatR for request/handler pattern

namespace Elux.Application.Queries.Expert.Handler
{
    /// <summary>
    /// Handles the query to get all experts with pagination.
    /// </summary>
    public class GetAllExpertsQueryHandler(ApplicationDbContext context) : IRequestHandler<GetAllExpertsQuery, PaginatedResponse<PaginatedList<ApplicationExpert>>>
    {
        /// <summary>
        /// Handles the query to retrieve a paginated list of experts.
        /// </summary>
        public async Task<PaginatedResponse<PaginatedList<ApplicationExpert>>> Handle(GetAllExpertsQuery request, CancellationToken cancellationToken)
        {
            // Fetching all experts from the database
            var experts = await context.Experts.ToListAsync(cancellationToken);

            // If no experts are found, return a failed response
            if (experts == null)
            {
                return PaginatedResponse<PaginatedList<ApplicationExpert>>.Failed();
            }

            // Creating a paginated list of experts based on the page index and page size provided
            var paginatedList = new PaginatedList<ApplicationExpert>(experts, request.PageIndex, request.PageSize);

            // Returning a paginated response containing the list of experts and pagination details
            return new PaginatedResponse<PaginatedList<ApplicationExpert>>(
                paginatedList,
                paginatedList.PageIndex,
                paginatedList.PageSize,
                paginatedList.TotalCount,
                paginatedList.TotalPages);
        }
    }
}
