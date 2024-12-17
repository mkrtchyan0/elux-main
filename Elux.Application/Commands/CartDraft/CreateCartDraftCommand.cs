using Elux.Domain.Entities;
using Elux.Domain.Responses;
using MediatR;

namespace Elux.Application.Commands.CartDraft
{
    public class CreateCartDraftCommand : IRequest<BaseResponse<CartDraftItem>>
    {
        public Guid? CartDraftId { get; set; }
        public List<BookServiceItemDraft> BookItems { get; set; }
    }
}