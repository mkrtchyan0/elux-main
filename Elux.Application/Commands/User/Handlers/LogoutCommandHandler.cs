using Elux.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elux.Application.Commands.User.Handlers
{
    public class LogoutCommandHandler : IRequestHandler<LogoutCommand>
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        public LogoutCommandHandler(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }
        async Task IRequestHandler<LogoutCommand>.Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            await _signInManager.SignOutAsync();
        }
    }
}
