using Elux.Domain.Entities;
using Elux.Domain.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elux.Application.Commands.Expert
{
    public class AddExpertCommand : IRequest<BaseResponse<ApplicationExpert>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Proffesion { get; set; }
        public string Description { get; set; }
        public int Experiense { get; set; }
    }
}
