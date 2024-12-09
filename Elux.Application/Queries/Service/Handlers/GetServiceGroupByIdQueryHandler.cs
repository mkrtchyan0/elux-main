using Elux.Dal.Data;
using Elux.Domain.Entities;
using Elux.Domain.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elux.Application.Queries.Service.Handlers
{
    public class GetServiceGroupByIdQueryHandler(ApplicationDbContext context) : IRequestHandler<GetServiceGroupById, BaseResponse<ServiceGroup>>
    {
        public async Task<BaseResponse<ServiceGroup>> Handle(GetServiceGroupById request, CancellationToken cancellationToken)
        {
			try
			{
                var serviceGroup = await context.ServiceGroups.FirstOrDefaultAsync(group => group.Id == request.Id);

                if (serviceGroup == null)
                {
                    return new BaseResponse<ServiceGroup>
                    {
                        Message = $"ServiceGroup by {request.Id} does not exist",
                        StatusCode = "404",
                        Succeeded = false
                    };
                }
                return BaseResponse<ServiceGroup>.Success(serviceGroup);
            }
            catch (Exception ex)
			{
                return new BaseResponse<ServiceGroup> { Message = ex.Message };
			}
        }
    }
}
