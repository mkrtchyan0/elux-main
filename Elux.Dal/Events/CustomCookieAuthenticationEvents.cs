using Elux.Dal.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace Elux.Dal.Events
{
    public class CustomCookieAuthenticationEvents(ApplicationDbContext DbContext) : CookieAuthenticationEvents
    {
        public override async Task ValidatePrincipal(CookieValidatePrincipalContext context)
        {
            var userPrincipal = context.Principal;

            // Retrieve the email claim from the user's claims.
            var email = (from c in userPrincipal.Claims
                         where c.Type == ClaimTypes.Email
                         select c.Value).FirstOrDefault();

            if (string.IsNullOrEmpty(email))
            {
                context.RejectPrincipal();
                await context.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                //// Check if the user is still valid; reject the principal if validation fails.
                //if (!_repository.ValidateUser(email))
                //{
                //    //if user isdeleted dont validate
                //    context.RejectPrincipal();
                //    await context.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                //}
            }
        }
    }
}