using Elux.Dal.Data;
using Elux.Domain.Models;
using Elux.Domain.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Elux.Application.Queries.Expert.Handler
{
    public class GetExpertBusyTimeQueryHandler(ApplicationDbContext context) : IRequestHandler<GetExpertBusyTimeQuery, BaseResponse<List<BookingModel>>>
    {
        public async Task<BaseResponse<List<BookingModel>>> Handle(GetExpertBusyTimeQuery request, CancellationToken cancellationToken)
        {
            var expert = await context.Experts.SingleAsync(x => x.Id == request.ExpertId, cancellationToken);
            if (expert == null)
            {
                throw new ArgumentException("Expert not found!");
            }
            var bookingDates = context.Bookings.Where(ex => ex.ExpertId == expert.Id);

            if (bookingDates == null)
            {
                throw new ArgumentException($"{expert.FirstName}'s Booking Dates not found!");
            }

            List<BookingModel> bookings = new List<BookingModel>();

            foreach (var bookingDate in bookingDates)
            {
                bookings.Add(new BookingModel
                {
                    Day = bookingDate.Day,
                    StartingTime = bookingDate.StartingTime,
                    EndingTime = bookingDate.EndingTime
                });
            }
            return BaseResponse<List<BookingModel>>.Success(bookings);
        }
    }
}
