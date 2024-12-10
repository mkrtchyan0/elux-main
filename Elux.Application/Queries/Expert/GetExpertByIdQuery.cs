using Elux.Domain.Entities; // Importing the ApplicationExpert entity
using Elux.Domain.Responses; // Importing the BaseResponse class
using MediatR; // For implementing the CQRS pattern (Command Query Responsibility Segregation)

namespace Elux.Application.Queries.Expert
{
    /// <summary>
    /// Query to get an expert by their ID.
    /// </summary>
    public class GetExpertByIdQuery : IRequest<BaseResponse<ApplicationExpert>>
    {
        /// <summary>
        /// Unique identifier for the expert.
        /// </summary>
        public Guid Id { get; set; }
    }
}
