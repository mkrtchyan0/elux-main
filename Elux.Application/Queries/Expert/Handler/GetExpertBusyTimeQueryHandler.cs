using Elux.Dal.Data;
using Elux.Domain.Entities;
using Elux.Domain.Models;
using Elux.Domain.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Elux.Application.Queries.Expert.Handler
{
    public class GetExpertBusyTimeQueryHandler(ApplicationDbContext context) : IRequestHandler<ExpertBookingsQuery, BaseResponse<List<BookingModel>>>
    {
        public async Task<BaseResponse<List<BookingModel>>> Handle(ExpertBookingsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var expert = await context.Experts.SingleAsync(x => x.Id == request.ExpertId, cancellationToken) ?? throw new ArgumentException("Expert not found!");

                var bookings = await context.Bookings.
                    Where(ex => ex.ExpertId == expert.Id && ex.DateTime == request.DateTime)
                    .Select(b => 
                    new BookingModel
                    {
                        DateTime = b.DateTime,  
                        StartingTime = b.StartingTime,
                        EndingTime = b.EndingTime,
                    })
                    .ToListAsync(cancellationToken);

                if (bookings == null)
                {
                    return BaseResponse<List<BookingModel>>.Success("No booking found!");
                }
                //if(CheckBooking(bookings, request.s))
                return BaseResponse<List<BookingModel>>.Success(bookings);

            }
            catch (Exception ex)
            {
                return BaseResponse<List<BookingModel>>.Failed(ex.Message);
            }
        }
        public bool CheckBooking(IQueryable<Booking> bookings, int startTime, int endTimne)
        {
            foreach (var booking in bookings)
            {
                if (startTime < booking.StartingTime && endTimne < booking.StartingTime
                    || startTime > booking.EndingTime && endTimne > booking.EndingTime)
                    return true;
            }
            return false;
        }
    }
}
