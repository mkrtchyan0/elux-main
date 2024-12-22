using Elux.Application.Queries.Expert.Handler;
using Elux.Dal.Data;
using Elux.Domain.Entities;
using Elux.Domain.Models;
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

            var bookItems = new List<Booking>();
            foreach (var item in bookDraftItems)
            {
                bookItems.Add(new Booking
                {
                    DateTime = item.ServiceDate,
                    StartingTime = item.ServiceDate.Hour,
                    EndingTime = item.ServiceDate.Hour + item.ServiceDuration,
                    ExpertId = item.ExpertId
                });
            }
            foreach (var bookItem in bookItems)
            {
                if (!GetExpertBusyTimeQueryHandler.CheckBooking(context.Bookings, bookItem.StartingTime, bookItem.EndingTime))
                    return AppResponse.Failed();
            }
            context.Bookings.AddRange(bookItems);
            context.BookServiceItems.AddRange(bookDraftItems);
            await context.SaveChangesAsync(cancellationToken);

            return AppResponse.Success();
        }
    }
}