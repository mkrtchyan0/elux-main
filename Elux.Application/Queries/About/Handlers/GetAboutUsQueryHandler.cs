using Elux.Dal.Data;
using Elux.Domain.Entities;
using Elux.Domain.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Elux.Application.Queries.About.Handlers
{
    public class GetAboutUsQueryHandler(ApplicationDbContext context) : IRequestHandler<GetAboutUsQuery, BaseResponse<AboutUs>>
    {
        public async Task<BaseResponse<AboutUs>> Handle(GetAboutUsQuery request, CancellationToken cancellationToken)
        {
            var about = await context.About.FirstOrDefaultAsync(cancellationToken);
            if (about != null)
            {
                return BaseResponse<AboutUs>.Success(about);
            }
            return BaseResponse<AboutUs>.Failed();
        }
    }
}
