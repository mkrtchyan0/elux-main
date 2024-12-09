using Elux.Dal.Data;
using Elux.Domain.Entities;
using Elux.Domain.Responses;
using Elux.Domain.Responses.User;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Elux.Application.Queries.User.Handlers
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, BaseResponse<UserResponse>>
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public GetUserByIdQueryHandler(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<BaseResponse<UserResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == request.Id);
            if (user == null)
            {
                return BaseResponse<UserResponse>.Failed();
            }
            var roles = await _userManager.GetRolesAsync(user);
            var result = new UserResponse
            {
                Id = request.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.Email,
                Role = roles.FirstOrDefault(),
            };
            return BaseResponse<UserResponse>.Success(result);
        }
    }
    public class GetUserByIdQueryValidator : AbstractValidator<GetUserByIdQuery>
    {
        public GetUserByIdQueryValidator()
        {
            // Guid validation  
            RuleFor(user => user.Id)
                .NotEmpty()
                .WithMessage("GUID is required.");
        }
    }
}
