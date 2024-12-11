using Elux.Domain.Responses;
using MediatR;

namespace Elux.Application.Queries.Expert
{
    public class GetExpertFreeTimeQuery : IRequest<ICollection<(DateTime, DateTime)>>
    {
        public Guid ExpertId { get; set; }
    }
}
