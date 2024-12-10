using Elux.Dal.Data; // Importing the ApplicationDbContext to interact with the database
using Elux.Domain.Entities; // Importing the ServiceGroup entity
using Elux.Domain.Responses; // Importing the BaseResponse class for standardized responses
using MediatR; // Importing MediatR to implement CQRS pattern
using Microsoft.EntityFrameworkCore; // Importing Entity Framework Core for async database operations

namespace Elux.Application.Queries.Service.Handlers
{
    /// <summary>
    /// Handles the query to get a ServiceGroup by its ID.
    /// </summary>
    public class GetServiceGroupByIdQueryHandler : IRequestHandler<GetServiceGroupById, BaseResponse<ServiceGroup>>
    {
        private readonly ApplicationDbContext _context;

        // Constructor injection of ApplicationDbContext to interact with the database
        public GetServiceGroupByIdQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Handles the GetServiceGroupById query.
        /// </summary>
        public async Task<BaseResponse<ServiceGroup>> Handle(GetServiceGroupById request, CancellationToken cancellationToken)
        {
            try
            {
                // Fetching the ServiceGroup by ID using Entity Framework
                var serviceGroup = await _context.ServiceGroups.FirstOrDefaultAsync(group => group.Id == request.Id);

                // If the ServiceGroup is not found, return a failed response with a message
                if (serviceGroup == null)
                {
                    return new BaseResponse<ServiceGroup>
                    {
                        Message = $"ServiceGroup with ID {request.Id} does not exist", // Custom message
                        StatusCode = "404", // HTTP Not Found status
                        Succeeded = false // Indicating the failure
                    };
                }

                // Return the successfully retrieved ServiceGroup
                return BaseResponse<ServiceGroup>.Success(serviceGroup);
            }
            catch (Exception ex)
            {
                // In case of an error, return a response with the exception message
                return new BaseResponse<ServiceGroup> { Message = ex.Message };
            }
        }
    }
}
