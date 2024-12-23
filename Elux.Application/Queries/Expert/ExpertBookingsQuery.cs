using Elux.Domain.Entities;
using Elux.Domain.Models;
using Elux.Domain.Responses;
using MediatR;

namespace Elux.Application.Queries.Expert
{
    public class ExpertBookingsQuery : IRequest<BaseResponse<List<Booking>>>
    {
        public Guid ExpertId { get; set; }

        public DateTime DateTime { get; set; }
    }
}
