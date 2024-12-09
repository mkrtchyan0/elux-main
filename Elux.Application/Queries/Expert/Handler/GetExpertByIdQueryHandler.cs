using Elux.Dal.Data;
using Elux.Domain.Entities;
using Elux.Domain.Responses;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Elux.Application.Queries.Expert.Handler
{
    public class GetExpertByIdQueryHandler(ApplicationDbContext context) : IRequestHandler<GetExpertByIdQuery, BaseResponse<ApplicationExpert>>
    {
        public async Task<BaseResponse<ApplicationExpert>> Handle(GetExpertByIdQuery request, CancellationToken cancellationToken)
        {
            var expert = await context.Experts.SingleAsync(x => x.Id == request.Id, cancellationToken);

            if (expert == null)
                return BaseResponse<ApplicationExpert>.Failed();
            return BaseResponse<ApplicationExpert>.Success(expert);
        }
    }
    public class GetExpertByIdQueryValidator : AbstractValidator<GetExpertByIdQuery>
    {
        public GetExpertByIdQueryValidator()
        {
            // Guid validation  
            RuleFor(user => user.Id)
                .NotEmpty()
                .WithMessage("GUID is required.");
        }
    }
}
