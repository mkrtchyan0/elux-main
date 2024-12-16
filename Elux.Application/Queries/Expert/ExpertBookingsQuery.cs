using Elux.Domain.Models;
using Elux.Domain.Responses;
using MediatR;

namespace Elux.Application.Queries.Expert
{
    public class ExpertBookingsQuery : IRequest<BaseResponse<List<BookingModel>>>
    {
        public Guid ExpertId { get; set; }

        public DateTime DateTime { get; set; }
    }
}
