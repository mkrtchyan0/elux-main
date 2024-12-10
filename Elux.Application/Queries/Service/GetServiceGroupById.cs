using Elux.Domain.Entities; // Importing the ServiceGroup entity class from the domain layer
using Elux.Domain.Responses; // Importing the response class to standardize API responses
using MediatR; // Importing MediatR for handling CQRS (Command Query Responsibility Segregation) pattern

namespace Elux.Application.Queries.Service
{
    /// <summary>
    /// Query to retrieve a service group by its ID.
    /// </summary>
    public class GetServiceGroupById : IRequest<BaseResponse<ServiceGroup>>
    {
        /// <summary>
        /// Gets or sets the ID of the service group.
        /// </summary>
        public Guid Id { get; set; }
    }
}
