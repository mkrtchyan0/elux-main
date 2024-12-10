using Elux.Domain.Entities; // Importing the ServiceGroup entity class from the domain layer
using MediatR; // Importing MediatR for implementing CQRS pattern (Command Query Responsibility Segregation)

namespace Elux.Application.Queries.Service
{
    /// <summary>
    /// Query to retrieve all service groups.
    /// </summary>
    public class GetAllServiceGroupsQuery : IRequest<List<ServiceGroup>>
    {
        // No additional properties are required for this query, as it's just fetching all service groups.
    }
}
