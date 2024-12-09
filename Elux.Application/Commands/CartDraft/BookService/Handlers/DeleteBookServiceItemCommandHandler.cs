using Elux.Application.Commands.CartDraft.BookService;
using Elux.Dal.Data;
using MediatR;

namespace Elux.Application.Commands.CartDraft.Handlers
{
    public class DeleteBookServiceItemCommandHandler(ApplicationDbContext context) : IRequestHandler<DeleteBookServiceItemCommand, bool>
    {
        public async Task<bool> Handle(DeleteBookServiceItemCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var deleteItems = context.CartDrafts.Where(x => x.Id == request.CartDraftId);
                context.RemoveRange(deleteItems);
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
