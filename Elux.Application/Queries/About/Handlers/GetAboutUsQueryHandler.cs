using Elux.Dal.Data;
using Elux.Domain.Entities;
using Elux.Domain.Responses;
using MediatR;

namespace Elux.Application.Queries.About.Handlers
{
    public class GetAboutUsQueryHandler(ApplicationDbContext context) : IRequestHandler<GetAboutUsQuery, BaseResponse<AboutUs>>
    {
        public async Task<BaseResponse<AboutUs>> Handle(GetAboutUsQuery request, CancellationToken cancellationToken)
        {
            var about = context.About.FirstOrDefault();
            if (about != null)
            {
                return BaseResponse<AboutUs>.Success(about);
            }
            return BaseResponse<AboutUs>.Failed();
        }
    }
}
