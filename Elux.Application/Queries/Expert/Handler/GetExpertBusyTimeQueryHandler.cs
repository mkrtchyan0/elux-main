using Elux.Dal.Data;
using Elux.Domain.Entities;
using Elux.Domain.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Elux.Application.Queries.Expert.Handler
{
    public class GetExpertBusyTimeQueryHandler(ApplicationDbContext context) : IRequestHandler<ExpertBookingsQuery, BaseResponse<List<Booking>>>
    {
        public async Task<BaseResponse<List<Booking>>> Handle(ExpertBookingsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var date = request.DateTime.Kind;
                var expert = await context.Experts.SingleAsync(x => x.Id == request.ExpertId, cancellationToken) ?? throw new ArgumentException("Expert not found!");

                var bookings = await context.Bookings.
                    Where(ex => ex.ExpertId == expert.Id && ex.Date == DateOnly.FromDateTime(request.DateTime))
                    .Select(b =>
                    new Booking
                    {
                        Date = b.Date,
                        Start = b.Start,
                        End = b.End,
                    })
                    .ToListAsync(cancellationToken);

                if (bookings == null)
                {
                    return BaseResponse<List<Booking>>.Success("No booking found!");
                }
                //if(CheckBooking(bookings, request.s))
                return BaseResponse<List<Booking>>.Success(bookings);

            }
            catch (Exception ex)
            {
                return BaseResponse<List<Booking>>.Failed(ex.Message);
            }
        }
        public static bool CheckBooking(IEnumerable<Booking> bookings, TimeOnly startTime, TimeOnly endTime)
        {
            TimeOnly opening = new TimeOnly(10, 00);
            TimeOnly ending = new TimeOnly(22, 00);

            if (startTime < opening || endTime > ending)
                return false;

            foreach (var booking in bookings)
            {
                if (!(startTime < booking.Start && endTime < booking.Start
                    || startTime > booking.End && endTime > booking.End))
                    return false;
            }
            return true;
        }
    }
}
