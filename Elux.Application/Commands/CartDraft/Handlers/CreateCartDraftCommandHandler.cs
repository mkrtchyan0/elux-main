using Elux.Dal.Data;
using Elux.Domain.Entities;
using Elux.Domain.Responses;
using MediatR;

namespace Elux.Application.Commands.CartDraft.Handlers
{
    public class CreateCartDraftCommandHandler(IMediator mediator, ApplicationDbContext context) : IRequestHandler<CreateCartDraftCommand, BaseResponse<CartDraftItem>>
    {
        public async Task<BaseResponse<CartDraftItem>> Handle(CreateCartDraftCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.CartDraftId != null)
                {
                    var id = (Guid)request.CartDraftId;
                    var result = await mediator.Send(
                        new UpdateCartDraftCommand { CartDraftId = id, Services = request.BookItems },
                        cancellationToken);
                    if (result)
                    {
                        var updatedCartDraft = context.CartDrafts.Find(id);
                        return BaseResponse<CartDraftItem>.Success(updatedCartDraft);
                    }
                    else
                        BaseResponse<CartDraftItem>.Failed("Cart draft can not updated.");
                }
                CartDraftItem newCartDraftItem = new()
                {
                    BookItems = request.BookItems,
                    TotalPrice = request.BookItems.Sum(s => s.TotalPrice),
                };
                context.CartDrafts.Add(newCartDraftItem);
                await context.SaveChangesAsync(cancellationToken);
                return BaseResponse<CartDraftItem>.Success(newCartDraftItem);
            }
            catch (Exception)
            {
                return BaseResponse<CartDraftItem>.Failed("Cart draft can not added.");
            }
        }
    }
}
