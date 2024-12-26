using Elux.Application.Queries.Expert.Handler;
using Elux.Dal.Data;
using Elux.Domain.Entities;
using Elux.Domain.Responses;
using MediatR;

namespace Elux.Application.Commands.Cart.Handler
{
    public class CreateCartCommandHandler(ApplicationDbContext context) : IRequestHandler<CreateCartCommand, BaseResponse<Booking>>
    {
        public async Task<BaseResponse<Booking>> Handle(CreateCartCommand request, CancellationToken cancellationToken)
        {
            var cartDraft = context.CartDrafts.Single(x => x.Id == request.CartDraftId) ?? throw new Exception("Draft not found!");

            var newCart = new CartItem { TotalPrice = cartDraft.TotalPrice };

            context.Carts.Add(newCart);

            var bookServiceItem = context.BookServiceItemsDraft
                .Where(x => x.CartDraftId == cartDraft.Id)
                .Select(x => new BookServiceItem
                {
                    CartId = newCart.Id,
                    ServiceDate = x.ServiceDate,
                    ExpertId = x.ExpertId,
                    ServiceDuration = x.ServiceDuration,
                    ServiceIds = x.ServiceIds,
                    TotalPrice = x.TotalPrice
                }).ToList();
            var bookItems = new List<Booking>();
            foreach (var item in bookServiceItem)
            {
                bookItems.Add(new Booking
                {
                    Date = DateOnly.FromDateTime(item.ServiceDate.Date),
                    Start = TimeOnly.FromDateTime(item.ServiceDate),
                    End = TimeOnly.FromDateTime(item.ServiceDate).AddMinutes(20),
                    ExpertId = item.ExpertId
                });
            }
            var failedBookItems = new List<Booking>();
            var succededBookItems = new List<Booking>();

            foreach (var bookItem in bookItems)
            {
                var booking = context.Bookings.Where(x => x.ExpertId == bookItem.ExpertId && x.Date == bookItem.Date);
                if (booking == null)
                    break;

                if (!GetExpertBusyTimeQueryHandler.CheckBooking(booking, bookItem.Start, bookItem.End))
                    failedBookItems.Add(bookItem);
                else
                    succededBookItems.Add(bookItem);
            }
            if (failedBookItems.Count != 0)
                return BaseResponse<Booking>.Failed(failedBookItems, "You can not book this Service(s).");

            context.Bookings.AddRange(bookItems);
            context.BookServiceItems.AddRange(bookServiceItem);
            await context.SaveChangesAsync(cancellationToken);

            return BaseResponse<Booking>.Success(succededBookItems);
        }
    }
}