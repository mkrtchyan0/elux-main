using Elux.Application.Queries.Expert.Handler;
using Elux.Dal.Data;
using Elux.Domain.Entities;
using Elux.Domain.Responses;
using MediatR;

namespace Elux.Application.Commands.Cart.Handler
{
    public class CreateCartCommandHandler(ApplicationDbContext context) : IRequestHandler<CreateCartCommand, AppResponse>
    {
        public async Task<AppResponse> Handle(CreateCartCommand request, CancellationToken cancellationToken)
        {
            var cartDraft = context.CartDrafts.Single(x => x.Id == request.CartDraftId) ?? throw new Exception("Draft not found!");

            var newCart = new CartItem { TotalPrice = cartDraft.TotalPrice };

            context.Carts.Add(newCart);

            var bookDraftItems = context.BookServiceItemsDraft
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
            var start = new TimeOnly(12, 00);
            var end = start.AddMinutes(110);
            var bookItems = new List<Booking>();
            foreach (var item in bookDraftItems)
            {
                bookItems.Add(new Booking
                {
                    Date = DateOnly.FromDateTime(item.ServiceDate.Date),
                    Start = TimeOnly.FromDateTime(item.ServiceDate.Date),
                    End = TimeOnly.FromDateTime(item.ServiceDate.Date).AddMinutes(20),
                    ExpertId = item.ExpertId
                });
            }
            foreach (var bookItem in bookItems)
            {
                var booking = context.Bookings.Where(x => x.ExpertId == bookItem.ExpertId && x.Date == bookItem.Date);
                if (!GetExpertBusyTimeQueryHandler.CheckBooking(booking, bookItem.Start, bookItem.End))
                    return AppResponse.Failed();
            }
            context.Bookings.AddRange(bookItems);
            context.BookServiceItems.AddRange(bookDraftItems);
            await context.SaveChangesAsync(cancellationToken);

            return AppResponse.Success();
        }
    }
}