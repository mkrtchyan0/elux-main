using Elux.Dal.Data; // Importing ApplicationDbContext to interact with the database
using Elux.Domain.Entities; // Importing the ServiceGroup entity
using Elux.Domain.Responses; // Importing BaseResponse for standardized responses
using FluentValidation; // For validation logic
using MediatR; // For the CQRS pattern implementation
using Microsoft.EntityFrameworkCore; // For async database operations with Entity Framework

namespace Elux.Application.Queries.Service.Handlers
{
    /// <summary>
    /// Handles the query to get a ServiceGroup by its ID.
    /// </summary>
    public class GetServiceByIdQueryHandler : IRequestHandler<GetServiceByIdQuery, BaseResponse<ServiceGroup>>
    {
        private readonly ApplicationDbContext _context;

        // Constructor injection for ApplicationDbContext
        public GetServiceByIdQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Handles the query to retrieve a ServiceGroup by ID.
        /// </summary>
        public async Task<BaseResponse<ServiceGroup>> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
        {
            // Fetch the service group by ID from the database asynchronously
            var service = await _context.ServiceGroups.FirstOrDefaultAsync(x => x.Id == request.Id);

            // If the service group is not found, return a failed response
            if (service == null)
                return BaseResponse<ServiceGroup>.Failed();

            // Return a successful response with the found service group
            return BaseResponse<ServiceGroup>.Success(service);
        }
    }

    /// <summary>
    /// Validator for the GetServiceByIdQuery to ensure the ID is valid.
    /// </summary>
    public class GetServiceByIdQueryValidator : AbstractValidator<GetServiceByIdQuery>
    {
        public GetServiceByIdQueryValidator()
        {
            // Ensure the ID is not empty
            RuleFor(query => query.Id)
                .NotEmpty()
                .WithMessage("GUID is required.");
        }
    }
}
