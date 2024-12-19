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
    public class GetAllServicesQueryHandler : IRequestHandler<GetAllServicesQuery, PaginatedResponse<PaginatedList<Elux.Domain.Entities.Service>>>
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
        public async Task<PaginatedResponse<PaginatedList<Elux.Domain.Entities.Service>>> Handle(GetAllServicesQuery request, CancellationToken cancellationToken)
        {
            // Fetch all ServiceGroups from the database
            var services = await _context.Services.ToListAsync(cancellationToken);

            // If no services are found, return a failed response
            if (services == null || !services.Any())
            {
                return PaginatedResponse<PaginatedList<Elux.Domain.Entities.Service>>.Failed();
            }
            if (request.ServiceGroupId == null)
            {
                var paginatedServicesList = new PaginatedList<Elux.Domain.Entities.Service>(services, request.PageIndex, request.PageSize);

                // Return a successful PaginatedResponse with pagination data
                return new PaginatedResponse<PaginatedList<Elux.Domain.Entities.Service>>(
                    paginatedServicesList,
                    paginatedServicesList.PageIndex,
                    paginatedServicesList.PageSize,
                    paginatedServicesList.TotalCount,
                    paginatedServicesList.TotalPages);
            }

            var servicesWithGroupId = services.Where(x => x.GroupId.ToString() == request.ServiceGroupId);

            var paginatedServicesWithGroupIdList = new PaginatedList<Elux.Domain.Entities.Service>(servicesWithGroupId, request.PageIndex, request.PageSize);

            // Return a successful PaginatedResponse with pagination data
            return new PaginatedResponse<PaginatedList<Elux.Domain.Entities.Service>>(
                paginatedServicesWithGroupIdList,
                paginatedServicesWithGroupIdList.PageIndex,
                paginatedServicesWithGroupIdList.PageSize,
                paginatedServicesWithGroupIdList.TotalCount,
                paginatedServicesWithGroupIdList.TotalPages);
        }
    }
}
