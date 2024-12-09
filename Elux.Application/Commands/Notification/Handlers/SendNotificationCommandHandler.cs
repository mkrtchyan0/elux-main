using MediatR;

namespace Elux.Application.Commands.Notification.Handlers
{
    public class SendNotificationCommandHandler : IRequestHandler<SendNotificationCommand, bool>
    {
        public async Task<bool> Handle(SendNotificationCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
