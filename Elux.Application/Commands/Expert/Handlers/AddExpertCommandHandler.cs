using Elux.Dal.Data;
using Elux.Domain.Entities;
using Elux.Domain.Responses;
using FluentValidation;
using MediatR;

namespace Elux.Application.Commands.Expert.Handlers
{
    public class AddExpertCommandHandler(ApplicationDbContext context) : IRequestHandler<AddExpertCommand, BaseResponse<ApplicationExpert>>
    {
        public async Task<BaseResponse<ApplicationExpert>> Handle(AddExpertCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var expert = new ApplicationExpert
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Description = request.Description,
                    Experiense = request.Experiense,
                    Proffesion = request.Proffesion
                };
                context.Add(expert);
                await context.SaveChangesAsync(cancellationToken);
                return BaseResponse<ApplicationExpert>.Success(expert);
            }
            catch (Exception ex)
            {
                return BaseResponse<ApplicationExpert>.Failed(ex.Message);
            }
        }
    }
    public class AddExpertCommandValidator : AbstractValidator<AddExpertCommand>
    {
        public AddExpertCommandValidator()
        {
            RuleFor(e => e.FirstName)
                .NotEmpty().WithMessage("Expert's FirstName cannot be empty.")
                .MaximumLength(32).WithMessage("Maximum symbols is 32");
            RuleFor(e => e.LastName)
                .NotEmpty().WithMessage("Expert's LastName cannot be empty.")
                .MaximumLength(32).WithMessage("Maximum symbols is 32");
            RuleFor(e => e.Description)
                .NotEmpty().WithMessage("Expert's Description cannot be empty.")
                .MaximumLength(2048).WithMessage("Maximum symbols is 2048");
            RuleFor(e => e.Experiense)
                .NotEmpty().WithMessage("Expert's Description cannot be empty.")
                .GreaterThan(0).WithMessage("Expert's Experiense must be greater than 0");
        }
    }
}
