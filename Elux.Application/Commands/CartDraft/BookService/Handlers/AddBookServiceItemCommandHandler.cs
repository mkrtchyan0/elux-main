using Elux.Application.Commands.CartDraft.BookService;
using Elux.Dal.Data;
using Elux.Domain.Entities;
using Elux.Domain.Models;
using MediatR;

namespace Elux.Application.Commands.CartDraft.Handlers
{
    public class AddBookServiceItemCommandHandler(ApplicationDbContext context) : IRequestHandler<AddBookServiceItemCommand, bool>
    {
        public async Task<bool> Handle(AddBookServiceItemCommand request, CancellationToken cancellationToken)
        {
            try
            {
                foreach (var item in request.Items)
                {
                    var newItem = new BookServiceItemDraft
                    {
                        CartDraftId = request.CartDraftId,
                        ServiceIds = item.ServiceIds,
                        ExpertId = item.ExpertId,
                        ServiceDuration = item.ServiceDuration,
                        ServiceDate = item.ServiceDate,
                        TotalPrice = item.TotalPrice,
                    };

                    Booking model = new()
                    {
                        Date = DateOnly.FromDateTime(newItem.ServiceDate),
                        Start = TimeOnly.FromDateTime( newItem.ServiceDate),
                        End = TimeOnly.FromDateTime(newItem.ServiceDate).AddMinutes(newItem.ServiceDuration),
                        ExpertId = newItem.ExpertId
                    };
                    context.BookServiceItemsDraft.Add(newItem);
                    context.Bookings.Add(model);
                }
                await context.SaveChangesAsync(cancellationToken);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

//var AnonType = new { Name = "ss", Age = 15.5m };
