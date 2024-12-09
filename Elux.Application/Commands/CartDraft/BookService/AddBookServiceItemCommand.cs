using Elux.Domain.Entities;
using MediatR;

namespace Elux.Application.Commands.CartDraft.BookService
{
    public class AddBookServiceItemCommand : IRequest<bool>
    {
        public Guid CartDraftId { get; set; }
        public List<BookServiceItem> Items {  get; set; } 
    }
}