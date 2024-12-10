using Elux.Dal.Data;
using Elux.Domain.Entities;
using Elux.Domain.Responses;
using FluentValidation;
using MediatR;

namespace Elux.Application.Commands.Services.Handlers
{
    /// <summary>
    /// Handler for the AddServiceCommand, responsible for adding a new service to the database.
    /// </summary>
    public class AddServiceCommandHandler : IRequestHandler<AddServiceCommand, BaseResponse<Service>>
    {
        private readonly ApplicationDbContext _ctx;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddServiceCommandHandler"/> class.
        /// </summary>
        /// <param name="ctx">The database context for interacting with the database.</param>
        public AddServiceCommandHandler(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        /// <summary>
        /// Handles the command to add a new service to the database.
        /// </summary>
        /// <param name="request">The request containing the data for the service.</param>
        /// <param name="token">The cancellation token for the operation.</param>
        /// <returns>A response indicating whether the service was successfully added.</returns>
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
                // Add the service to the context
                _ctx.Add(service);
                // Save changes to the database
                await _ctx.SaveChangesAsync(token);
                // Return a successful response with the created service
                return BaseResponse<Service>.Success(service);
            }
            catch (Exception ex)
            {
                // Return a failed response with the exception message if an error occurs
                return BaseResponse<Service>.Failed(ex.Message);
            }
        }
    }

    /// <summary>
    /// Validator for the AddServiceCommand, responsible for validating the input data for creating a service.
    /// </summary>
    public class AddServiceCommandValidator : AbstractValidator<AddServiceCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddServiceCommandValidator"/> class.
        /// </summary>
        public AddServiceCommandValidator()
        {
            // Validate that the ServiceGroupId is not null
            RuleFor(s => s.ServiceGroupId)
                .NotNull()
                .WithMessage("Service group ID cannot be null.");
        }
    }

}
