using MediatR;

namespace Elux.Application.Commands.Notification
{
    public class SendNotificationCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
    }
}
