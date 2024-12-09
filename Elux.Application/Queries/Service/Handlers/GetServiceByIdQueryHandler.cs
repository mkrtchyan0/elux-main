using Elux.Dal.Data;
using Elux.Domain.Entities;
using Elux.Domain.Responses;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Elux.Application.Queries.Service.Handlers
{
    public class GetServiceByIdQueryHandler(ApplicationDbContext context) : IRequestHandler<GetServiceByIdQuery, BaseResponse<ServiceGroup>>
    {
        public async Task<BaseResponse<ServiceGroup>> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
        {
            var service = await context.ServiceGroups.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (service == null)
                return BaseResponse<ServiceGroup>.Failed();
            return BaseResponse<ServiceGroup>.Success(service);
        }
    }
    public class GetServiceByIdQueryValidator : AbstractValidator<GetServiceByIdQuery>
    {
        public GetServiceByIdQueryValidator()
        {
            // Guid validation  
            RuleFor(user => user.Id)
                .NotEmpty()
                .WithMessage("GUID is required.");
        }
    }
}
