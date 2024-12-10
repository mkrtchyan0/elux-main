using Elux.Domain.Entities; // Importing the ServiceGroup entity class from the domain layer
using Elux.Domain.HelperClasses; // Importing helper classes for pagination and list management
using Elux.Domain.Responses; // Importing response classes for standardized API responses
using MediatR; // Importing MediatR for implementing CQRS pattern (Command Query Responsibility Segregation)

namespace Elux.Application.Queries.Service
{
    /// <summary>
    /// Query to retrieve a paginated list of services for a specific service group.
    /// </summary>
    public class GetAllServicesQuery : IRequest<PaginatedResponse<PaginatedList<ServiceGroup>>>
    {
        /// <summary>
        /// Gets or sets the ID of the service group to filter services.
        /// </summary>
        public string ServiceGroupId { get; set; }

        /// <summary>
        /// Gets or sets the page index for pagination (starting from 0).
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// Gets or sets the page size for pagination (number of items per page).
        /// </summary>
        public int PageSize { get; set; }
    }
}
