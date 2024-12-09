using Elux.Domain.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elux.Application.Commands.Expert
{
    public class DeleteExpertCommand : IRequest<AppResponse>
    {
        public Guid Id { get; set; }
    }
}
