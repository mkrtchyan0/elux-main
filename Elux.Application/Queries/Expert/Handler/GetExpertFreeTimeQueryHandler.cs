using Elux.Dal.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Elux.Application.Queries.Expert.Handler
{
    public class GetExpertFreeTimeQueryHandler(ApplicationDbContext context) : IRequestHandler<GetExpertFreeTimeQuery, ICollection<(DateTime, DateTime)>>
    {
        public async Task<ICollection<(DateTime, DateTime)>> Handle(GetExpertFreeTimeQuery request, CancellationToken cancellationToken)
        {
            var expert = await context.Experts.SingleAsync(x => x.Id == request.ExpertId, cancellationToken);
            if (expert == null)
            {
                throw new ArgumentException("Expert not found!");
            }
            var bookingDates = context.Bookings;
            
            foreach ( var bookingDate in bookingDates)
            {

            }
            return new List<(DateTime, DateTime)>();
        }
    }
}
