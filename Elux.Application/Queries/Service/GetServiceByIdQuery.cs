using Elux.Domain.Entities; // Importing the ServiceGroup entity class from the domain layer
using Elux.Domain.Responses; // Importing the response class to standardize API responses
using MediatR; // Importing MediatR for handling CQRS (Command Query Responsibility Segregation) pattern

namespace Elux.Application.Queries.Service
{
    /// <summary>
    /// Query to retrieve a service by its ID.
    /// </summary>
    public class GetServiceByIdQuery : IRequest<BaseResponse<Elux.Domain.Entities.Service>>
    {
        /// <summary>
        /// Gets or sets the ID of the service.
        /// </summary>
        public Guid Id { get; set; }
    }
}
