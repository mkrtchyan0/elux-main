using Elux.Domain.Models;
using Elux.Domain.Responses;
using MediatR;

namespace Elux.Application.Queries.Expert
{
    public class GetExpertBusyTimeQuery : IRequest<BaseResponse<List<BookingModel>>>
    {
        public Guid ExpertId { get; set; }
    }
}
