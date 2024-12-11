using Elux.Domain.Entities;
using MediatR;

namespace Elux.Application.Commands.CartDraft.BookService
{
    public class DeleteBookServiceItemCommand : IRequest<bool>
    {
        public Guid CartDraftId { get; set; }
    }
}
