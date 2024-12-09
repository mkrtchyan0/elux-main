using Elux.Domain.Entities;
using MediatR;

namespace Elux.Application.Commands.CartDraft.BookService
{
    public class DeleteBookServiceItemCommand : IRequest<bool>
    {
        //public Guid CartDraftItemId { get; set; }
        public Guid CartDraftId { get; set; }
    }
}
