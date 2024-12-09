using Elux.Application.Commands.User;
using Elux.Dal.Data;
using Elux.Domain.Entities;
using Elux.Domain.Responses;
using FluentValidation;
using MediatR;

namespace Elux.Application.Commands.Services.Handlers
{
    public class AddServiceGroupCommandHandler (ApplicationDbContext ctx): IRequestHandler<AddServiceGroupCommand, BaseResponse<ServiceGroup>>
    {
        public async Task<BaseResponse<ServiceGroup>> Handle(AddServiceGroupCommand request, CancellationToken token)
        {
            try
            {
                var group = new ServiceGroup
                {
                    ServiceGroupName = request.ServiceGroupName,
                    ServiceDescription = request.ServiceDescription,
                    Picture = request.Picture,
                };
                ctx.Add(group);
                await ctx.SaveChangesAsync(token);
                return BaseResponse<ServiceGroup>.Success(group);
            }
            catch (Exception ex)
            {
                return BaseResponse<ServiceGroup>.Failed(ex.Message);
            }
        }
    }
    public class AddServiceGroupCommandValidator : AbstractValidator<AddServiceGroupCommand>
    {
        public AddServiceGroupCommandValidator()
        {
            RuleFor(s => s.ServiceGroupName)
                .NotEmpty()
                .WithMessage("Name can not be empty.");
        }
    }
}
