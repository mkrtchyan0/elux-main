using MediatR;

namespace Elux.Application.Commands.Question
{
    public class SendQuestionCommand : IRequest<(bool, string)>
    {
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public int PhoneNumber { get; set; }
        public string YourMessage { get; set; }
    }
}
