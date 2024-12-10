using Elux.Dal.Data; // Importing the ApplicationDbContext class
using Elux.Domain.Entities; // Importing ApplicationExpert entity
using Elux.Domain.Responses; // Importing BaseResponse class
using FluentValidation; // Importing FluentValidation for validation
using MediatR; // Importing MediatR for handling CQRS requests
using Microsoft.EntityFrameworkCore; // Importing EF Core extensions

namespace Elux.Application.Queries.Expert.Handler
{
    /// <summary>
    /// Handles the GetExpertById query to fetch an expert by their ID.
    /// </summary>
    public class GetExpertByIdQueryHandler(ApplicationDbContext context) : IRequestHandler<GetExpertByIdQuery, BaseResponse<ApplicationExpert>>
    {
        /// <summary>
        /// Handles the query to get an expert by ID from the database.
        /// </summary>
        public async Task<BaseResponse<ApplicationExpert>> Handle(GetExpertByIdQuery request, CancellationToken cancellationToken)
        {
            // Fetching the expert from the database by their ID
            var expert = await context.Experts.SingleAsync(x => x.Id == request.Id, cancellationToken);

            // If no expert found, return a failed response
            if (expert == null)
                return BaseResponse<ApplicationExpert>.Failed();

            // Return a successful response with the expert data
            return BaseResponse<ApplicationExpert>.Success(expert);
        }
    }

    /// <summary>
    /// Validator for GetExpertByIdQuery to ensure the ID is provided.
    /// </summary>
    public class GetExpertByIdQueryValidator : AbstractValidator<GetExpertByIdQuery>
    {
        public GetExpertByIdQueryValidator()
        {
            // Ensures that the GUID for the expert's ID is not empty
            RuleFor(expert => expert.Id)
                .NotEmpty()
                .WithMessage("GUID is required.");
        }
    }
}
