using Elux.Dal.Data;
using MediatR;

namespace Elux.Application.Queries.Expert.Handler
{
    public class GetExpertFreeTimeQueryHandler(ApplicationDbContext context) : IRequestHandler<GetExpertFreeTimeQuery, ICollection<(DateTime, DateTime)>>
    {
        public async Task<ICollection<(DateTime, DateTime)>> Handle(GetExpertFreeTimeQuery request, CancellationToken cancellationToken)
        {
            var expert = context.Experts.FirstOrDefault(x => x.Id == request.ExpertId);
            if (expert == null)
            {
                throw new ArgumentException("Expert not found!");
            }
            var bookingDates = context.Bookings;
            
            foreach ( var bookingDate in bookingDates)
            {

            }
        }
    }
}
