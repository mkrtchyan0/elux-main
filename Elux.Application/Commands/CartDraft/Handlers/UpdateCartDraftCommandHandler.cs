using Elux.Application.Commands.CartDraft.BookService;
using Elux.Dal.Data;
using MediatR;

namespace Elux.Application.Commands.CartDraft.Handlers
{
    public class UpdateCartDraftCommandHandler(IMediator mediator, ApplicationDbContext context) : IRequestHandler<UpdateCartDraftCommand, bool>
    {
        public async Task<bool> Handle(UpdateCartDraftCommand request, CancellationToken cancellationToken)
        {
            try
            {
                //Add trancation Vardan jan!!!!!!!
                var deleteResult = await mediator.Send(new DeleteBookServiceItemCommand { CartDraftId = request.CartDraftId }, cancellationToken);
                var addResult = await mediator.Send(new AddBookServiceItemCommand { CartDraftId = request.CartDraftId, Items = request.Services }, cancellationToken);
                await context.SaveChangesAsync(cancellationToken);
                if (deleteResult && addResult)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
