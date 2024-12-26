using Elux.Domain.Entities;
using Elux.Domain.HelperClasses;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Elux.Application.Commands.Notification.Handlers
{
    public class SendNotificationCommandHandler(UserManager<ApplicationUser> userManager) : IRequestHandler<SendNotificationCommand, bool>
    {
        readonly EmailService emailService = new("smtp.gmail.com", 587, "smarttaxam@gmail.com", "qmkcevtbftufhlrm");
        const string toEmail = "vardanmkrtchyan171@gmail.com";

        public async Task<bool> Handle(SendNotificationCommand request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByIdAsync(request.Id.ToString());
            if (user == null)
                return false;

            var messagesEnd = $".\n\n\n{user.FirstName},\n{user.LastName},\n{user.Email}.";

            var result = await emailService.SendEmailAsync(toEmail, request.Message + messagesEnd);
            if (result)
                return true;
            return false;
        }
    }
}
