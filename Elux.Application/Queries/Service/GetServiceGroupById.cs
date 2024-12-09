using Elux.Domain.Entities;
using Elux.Domain.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elux.Application.Queries.Service
{
    public class GetServiceGroupById : IRequest<BaseResponse<ServiceGroup>>
    {
        public Guid Id { get; set; }
    }
}
