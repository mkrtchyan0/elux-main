using Elux.Domain.Entities;
using Elux.Domain.Responses;
using MediatR;

namespace Elux.Application.Commands.CartDraft
{
    public class UpdateCartDraftCommand : IRequest<bool>
    {
        public Guid CartDraftId { get; set; }
        public List<BookServiceItem> Services { get; set; }
    }
}
