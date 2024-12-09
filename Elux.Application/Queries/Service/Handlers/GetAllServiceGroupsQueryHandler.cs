using Elux.Dal.Data;
using Elux.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elux.Application.Queries.Service.Handlers
{
    public class GetAllServiceGroupsQueryHandler(ApplicationDbContext context) : IRequestHandler<GetAllServiceGroupsQuery, List<ServiceGroup>>
    {
        public async Task<List<ServiceGroup>> Handle(GetAllServiceGroupsQuery request, CancellationToken cancellationToken)
        {
			try
			{
				var groups = context.ServiceGroups;

				if (groups == null)
				{
					throw new ArgumentNullException(nameof(groups));
				}
				return groups.ToList();
			}
			catch (Exception)
			{
				throw new Exception();
			}
        }
    }
}
