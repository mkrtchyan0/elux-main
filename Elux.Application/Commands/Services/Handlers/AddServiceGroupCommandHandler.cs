using Elux.Dal.Data;
using Elux.Domain.Entities;
using Elux.Domain.Responses;
using FluentValidation;
using MediatR;

namespace Elux.Application.Commands.Services.Handlers
{
    /// <summary>
    /// Handler for the AddServiceGroupCommand, responsible for adding a new service group to the database.
    /// </summary>
    public class AddServiceGroupCommandHandler : IRequestHandler<AddServiceGroupCommand, BaseResponse<ServiceGroup>>
    {
        private readonly ApplicationDbContext _ctx;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddServiceGroupCommandHandler"/> class.
        /// </summary>
        /// <param name="ctx">The database context for interacting with the database.</param>
        public AddServiceGroupCommandHandler(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        /// <summary>
        /// Handles the command to add a new service group to the database.
        /// </summary>
        /// <param name="request">The request containing the data for the service group.</param>
        /// <param name="token">The cancellation token for the operation.</param>
        /// <returns>A response indicating whether the service group was successfully added.</returns>
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
                // Add the service group to the context
                _ctx.Add(group);
                // Save changes to the database
                await _ctx.SaveChangesAsync(token);
                // Return a successful response with the created service group
                return BaseResponse<ServiceGroup>.Success(group);
            }
            catch (Exception ex)
            {
                // Return a failed response with the exception message if an error occurs
                return BaseResponse<ServiceGroup>.Failed(ex.Message);
            }
        }
    }

    /// <summary>
    /// Validator for the AddServiceGroupCommand, responsible for validating the input data for creating a service group.
    /// </summary>
    public class AddServiceGroupCommandValidator : AbstractValidator<AddServiceGroupCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddServiceGroupCommandValidator"/> class.
        /// </summary>
        public AddServiceGroupCommandValidator()
        {
            // Validate that the service group name is not empty
            RuleFor(s => s.ServiceGroupName)
                .NotEmpty()
                .WithMessage("Name can not be empty.");
        }
    }

}
