using Elux.Domain.Entities;
using Elux.Domain.Responses;
using MediatR;

namespace Elux.Application.Queries.Expert
{
    public class GetExpertByIdQuery : IRequest<BaseResponse<ApplicationExpert>>
    {
        public Guid Id { get; set; }
    }
}
