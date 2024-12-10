using Elux.Dal.Data; // Importing ApplicationDbContext for database interaction
using Elux.Domain.Entities; // Importing ServiceGroup entity
using MediatR; // For CQRS implementation

namespace Elux.Application.Queries.Service.Handlers
{
    /// <summary>
    /// Handles the query to get all ServiceGroups.
    /// </summary>
    public class GetAllServiceGroupsQueryHandler : IRequestHandler<GetAllServiceGroupsQuery, List<ServiceGroup>>
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
        public async Task<List<ServiceGroup>> Handle(GetAllServiceGroupsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                // Retrieve the ServiceGroups from the context
                var groups = _context.ServiceGroups;

                // If no groups are found, throw an exception
                if (groups == null || !groups.Any())
                {
                    throw new ArgumentNullException(nameof(groups), "No service groups found.");
                }

                // Return the list of groups
                return groups.ToList();
            }
            catch (Exception ex)
            {
                // Log the exception (optional: implement logging)
                throw new Exception("An error occurred while fetching service groups.", ex);
            }
        }
    }
}
