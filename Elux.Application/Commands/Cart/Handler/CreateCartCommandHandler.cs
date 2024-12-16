using Elux.Dal.Data;
using Elux.Domain.Responses;
using MediatR;

namespace Elux.Application.Commands.Cart.Handler
{
    public class CreateCartCommandHandler(ApplicationDbContext context) : IRequestHandler<CreateCartCommand, AppResponse>
    {
        public async Task<AppResponse> Handle(CreateCartCommand request, CancellationToken cancellationToken)
        {
            var cartDraft = context.CartDrafts.Single(x => x.Id == request.CartDraftId) ?? throw new Exception("Draft not found!");

            var bookItems = cartDraft.BookItems.ToList() ?? throw new Exception("Books not found!");

            

        }
    }
}