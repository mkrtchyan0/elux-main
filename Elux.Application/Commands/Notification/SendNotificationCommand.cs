using MediatR;

namespace Elux.Application.Commands.Notification
{
    public class SendNotificationCommand : IRequest<bool>
    {
        public Guid QuestionId { get; set; }
    }
}
