using Elux.Domain.Entities;
using MediatR;

namespace Elux.Application.Queries.Service
{
    public class GetAllServiceGroupsQuery : IRequest<List<ServiceGroup>>
    {

    }
}
