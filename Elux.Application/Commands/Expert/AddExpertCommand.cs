using Elux.Domain.Entities;
using Elux.Domain.Responses;
using MediatR;

namespace Elux.Application.Commands.Expert
{
    public class AddExpertCommand : IRequest<BaseResponse<ApplicationExpert>>
    {
        //AddExpertCommand
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Proffesion { get; set; }
        public string Description { get; set; }
        public int Experiense { get; set; }
    }
}
