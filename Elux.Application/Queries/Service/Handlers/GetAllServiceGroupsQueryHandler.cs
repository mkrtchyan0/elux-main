using Elux.Dal.Data; // Importing ApplicationDbContext for database interaction
using Elux.Domain.Entities; // Importing ServiceGroup entity
using Elux.Domain.HelperClasses;
using Elux.Domain.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore; // For CQRS implementation

namespace Elux.Application.Queries.Service.Handlers
{
    /// <summary>
    /// Handles the query to get all ServiceGroups.
    /// </summary>
    public class GetAllServiceGroupsQueryHandler : IRequestHandler<GetAllServiceGroupsQuery, PaginatedList<Elux.Domain.Entities.Service>>
    {
        private readonly ApplicationDbContext _context;

        // Constructor injection of ApplicationDbContext to interact with the database
        public GetAllServiceGroupsQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Handles the GetAllServiceGroupsQuery to return a list of all ServiceGroups.
        /// </summary>
        public async Task<PaginatedList<Elux.Domain.Entities.Service>> Handle(GetAllServiceGroupsQuery request, CancellationToken cancellationToken)
        {
            try
            {  // Fetch all ServiceGroups from the database
                var services = _context.Services.ToList();//.ToListAsync(cancellationToken);

                // If no services are found, return a failed response
                if (services == null || !services.Any())
                {
                    return null;
                }
                if (request.ServiceGroupId == null)
                {
                    return new PaginatedList<Elux.Domain.Entities.Service>(services, request.PageIndex, request.PageSize);
                }

                var servicesWithGroupId = services.Where(x => x.GroupId.ToString() == request.ServiceGroupId);

                return new PaginatedList<Elux.Domain.Entities.Service>(servicesWithGroupId, request.PageIndex, request.PageSize);
            }
            catch (Exception ex)
            {
                // Log the exception (optional: implement logging)
                //throw new Exception("An error occurred while fetching service groups.", ex);
                return null;
            }
        }
    }
}
