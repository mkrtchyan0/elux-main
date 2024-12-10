using Elux.Domain.Entities;
using Elux.Domain.Responses;
using MediatR;

namespace Elux.Application.Queries.About
{
    public class GetAboutUsQuery : IRequest<BaseResponse<AboutUs>>
    {

    }
}
