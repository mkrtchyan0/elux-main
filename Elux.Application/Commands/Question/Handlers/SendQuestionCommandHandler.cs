using Elux.Application.Commands.Notification;
using Elux.Dal.Data;
using Elux.Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Elux.Application.Commands.Question.Handlers
{
    public class SendQuestionCommandHandler(ApplicationDbContext context, IMediator mediator, IConfiguration configuration) : IRequestHandler<SendQuestionCommand, (bool, string)>
    {
        public async Task<(bool, string)> Handle(SendQuestionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var question = new ContactRequest
                {
                    IsRead = false,
                    EmailAddress = request.EmailAddress,
                    FullName = request.FullName,
                    PhoneNumber = request.PhoneNumber,
                    YourMessage = request.YourMessage
                };
                context.ContactRequests.Add(question);
                await context.SaveChangesAsync(cancellationToken);
                //await mediator.Send(new SendNotificationCommand { QuestionId = question.Id }, cancellationToken);

                return (true, "Message saved.");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
        public class SendQuestionCommandValidator : AbstractValidator<SendQuestionCommand>
        {
            public SendQuestionCommandValidator()
            {
                RuleFor(question => question.EmailAddress)
                    .EmailAddress().WithMessage("Email not a valid.")
                    .NotEmpty().WithMessage("Email can't be empty.");
                RuleFor(question => question.PhoneNumber)
                    .NotEmpty().WithMessage("PhoneNumber can't be empty");
                RuleFor(question => question.FullName)
                    .NotEmpty().WithMessage("FullName can't be empty")
                    .MaximumLength(32).WithMessage("Maximum symbols is 32");
                RuleFor(question => question.YourMessage)
                    .NotEmpty().WithMessage("Message can't be empty")
                    .MaximumLength(1024).WithMessage("Maximum symbols is 1024");
            }
        }
    }
}
