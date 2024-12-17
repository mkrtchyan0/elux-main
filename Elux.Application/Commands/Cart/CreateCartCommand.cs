using Elux.Domain.Entities;
using Elux.Domain.Responses;
using MediatR;

namespace Elux.Application.Commands.Cart
{
    public class CreateCartCommand : IRequest<AppResponse>
    {
        public Guid CartDraftId { get; set; }
    }
}
