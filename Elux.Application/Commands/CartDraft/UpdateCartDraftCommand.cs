using Elux.Domain.Entities;
using Elux.Domain.Models;
using Elux.Domain.Responses;
using MediatR;

namespace Elux.Application.Commands.CartDraft
{
    public class UpdateCartDraftCommand : IRequest<bool>
    {
        public Guid CartDraftId { get; set; }
        public List<BookServiceItemDraftModel> Services { get; set; }
    }
}
