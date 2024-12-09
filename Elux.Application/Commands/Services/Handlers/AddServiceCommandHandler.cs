using Elux.Dal.Data;
using Elux.Domain.Entities;
using Elux.Domain.Responses;
using FluentValidation;
using MediatR;

namespace Elux.Application.Commands.Services.Handlers
{
    public class AddServiceCommandHandler(ApplicationDbContext ctx) : IRequestHandler<AddServiceCommand, BaseResponse<Service>>
    {
        public async Task<BaseResponse<Service>> Handle(AddServiceCommand request, CancellationToken token)
        {
            try
            {
                var service = new Service
                {
                    GroupId = request.ServiceGroupId,
                    ServiceName = request.ServiceName,
                    Duration = request.Duration,
                    Price = request.Price,
                };
                ctx.Add(service);
                await ctx.SaveChangesAsync(token);
                return BaseResponse<Service>.Success(service);
            }
            catch (Exception ex)
            {
                return BaseResponse<Service>.Failed(ex.Message);
            }
        }
    }
    public class AddServiceCommandValidator : AbstractValidator<AddServiceCommand>
    {
        public AddServiceCommandValidator()
        {
            RuleFor(s => s.ServiceGroupId)
                .NotNull()
                .WithMessage("Name can not be null.");
        }
    }
}
