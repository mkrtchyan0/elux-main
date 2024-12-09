using Elux.Dal.Data;
using Elux.Domain.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elux.Application.Commands.Expert.Handlers
{
    public class DeleteExpertCommandHandler(ApplicationDbContext context) : IRequestHandler<DeleteExpertCommand, AppResponse>
    {
        public async Task<AppResponse> Handle(DeleteExpertCommand request, CancellationToken cancellationToken)
        {
			try
			{
				var expert = await context.Experts.FirstOrDefaultAsync(e => e.Id == request.Id);

				if (expert == null)
				{
					return new AppResponse
					{
						Message = "Expert not exists",
						StatusCode = "404",
						Succeeded = false
					};
				}
				context.Experts.Remove(expert);
				await context.SaveChangesAsync(cancellationToken);
				return new AppResponse
				{
					Message = $"{expert.FirstName}  {expert.LastName} deleted successfuly",
					StatusCode = "200",
					Succeeded = true 
				};
			}
			catch (Exception ex)
			{
				return new AppResponse
				{
					StatusCode = "400",
					Succeeded = false,
					Message = ex.Message
				};
			}
        }
    }
}
