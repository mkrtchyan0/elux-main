using Elux.Dal.Data; // Importing ApplicationDbContext for database interaction
using Elux.Domain.Entities; // Importing the ServiceGroup entity
using Elux.Domain.HelperClasses; // Importing helper classes like PaginatedList
using Elux.Domain.Responses; // Importing PaginatedResponse for standard responses
using MediatR;
using Microsoft.EntityFrameworkCore; // For CQRS implementation

namespace Elux.Application.Queries.Service.Handlers
{
    /// <summary>
    /// Handles the query to get all ServiceGroups with pagination support.
    /// </summary>
    public class GetAllServicesQueryHandler : IRequestHandler<GetAllServicesQuery, PaginatedResponse<PaginatedList<ServiceGroup>>>
    {
        private readonly ApplicationDbContext _context;

        // Constructor injection of ApplicationDbContext to interact with the database
        public GetAllServicesQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Handles the GetAllServicesQuery to return a paginated list of ServiceGroups.
        /// </summary>
        public async Task<PaginatedResponse<PaginatedList<ServiceGroup>>> Handle(GetAllServicesQuery request, CancellationToken cancellationToken)
        {
            // Fetch all ServiceGroups from the database
            var services = await _context.ServiceGroups.ToListAsync(cancellationToken);

            // If no services are found, return a failed response
            if (services == null || !services.Any())
            {
                return PaginatedResponse<PaginatedList<ServiceGroup>>.Failed();
            }

            // Create a PaginatedList based on the services retrieved and pagination info
            var paginatedList = new PaginatedList<ServiceGroup>(services, request.PageIndex, request.PageSize);

            // Return a successful PaginatedResponse with pagination data
            return new PaginatedResponse<PaginatedList<ServiceGroup>>(
                paginatedList,
                paginatedList.PageIndex,
                paginatedList.PageSize,
                paginatedList.TotalCount,
                paginatedList.TotalPages);
        }
    }
}
