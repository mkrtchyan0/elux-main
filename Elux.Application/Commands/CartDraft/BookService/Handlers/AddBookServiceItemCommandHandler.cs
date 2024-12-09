using Elux.Application.Commands.CartDraft.BookService;
using Elux.Dal.Data;
using Elux.Domain.Entities;
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
                    var newItem = new BookServiceItem
                    {
                        DraftId = item.DraftId,
                        SubServiceId = item.SubServiceId,
                        ExpertsId = item.ExpertsId,
                        ServiceDuration = item.ServiceDuration,
                        ServiceDate = item.ServiceDate,
                        TotalPrice = item.TotalPrice,
                    };
                    context.BookServiceItems.Add(newItem);
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
