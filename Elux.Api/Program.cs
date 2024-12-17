using Elux.Api.Extensions;
using Elux.Application.Commands.User;
using Elux.Application.Commands.User.Handlers;
using Elux.Dal.Data;
using Elux.Dal.Events;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

namespace Elux.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            #region Comment 1
            //builder.Services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres")));
            #endregion

            var connectionString = builder.Configuration.GetConnectionString("Postgres");

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new NotSupportedException("Postgres connection string is not configured.");
            }
            // Extension method for DbContext
            builder.AddCustomDbContext();

            //builder.Services.AddCustomDbContextByServices(builder.Configuration);

            // Extension method for Identity configuration
            builder.Services.AddCustomIdentity();

            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(RegisterCommand).Assembly));

            #region Comment 2
            // Add Identity services
            //builder.Services.AddIdentity<ApplicationUser, IdentityRole<Guid>>(options =>
            //{
            //    options.SignIn.RequireConfirmedPhoneNumber = false;
            //    options.SignIn.RequireConfirmedAccount = false;
            //    options.SignIn.RequireConfirmedEmail = false;

            //    options.Password.RequireDigit = true;
            //    options.Password.RequireLowercase = true;
            //    options.Password.RequireUppercase = true;
            //    options.Password.RequireNonAlphanumeric = false;
            //    options.Password.RequiredLength = 6;
            //})
            //.AddSignInManager<SignInManager<ApplicationUser>>()
            //.AddUserManager<UserManager<ApplicationUser>>()
            //.AddRoles<IdentityRole<Guid>>()
            //.AddRoleManager<RoleManager<IdentityRole<Guid>>>()
            //.AddEntityFrameworkStores<ApplicationDbContext>()
            //.AddDefaultTokenProviders();

            //builder.Services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //.AddCookie(options =>
            //{
            //    options.EventsType = typeof(CustomCookieAuthenticationEvents);
            //    options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
            //    options.Cookie.HttpOnly = true;
            //    options.Cookie.SameSite = SameSiteMode.None;
            //    options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
            //    options.SlidingExpiration = true;
            //    options.Cookie.Name = "EluxCookies";
            //});
            #endregion 

            builder.Services.AddScoped<CustomCookieAuthenticationEvents>();

            builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters().AddValidatorsFromAssemblyContaining<RegisterCommandValidator>();

            //Extension method for Swagger Groups
            builder.Services.AddCustomSwagger();
            #region Comment 3
            //builder.Services.AddSwaggerGen(options =>
            //{
            //    options.SwaggerDoc("account", new Microsoft.OpenApi.Models.OpenApiInfo
            //    {
            //        Title = "Accounts API",
            //        Version = "v1"
            //    });

            //    options.SwaggerDoc("services", new Microsoft.OpenApi.Models.OpenApiInfo
            //    {
            //        Title = "Services API",
            //        Version = "v1"
            //    });

            //    options.SwaggerDoc("cart", new Microsoft.OpenApi.Models.OpenApiInfo
            //    {
            //        Title = "Cart API",
            //        Version = "v1"
            //    });

            //    options.SwaggerDoc("expert", new Microsoft.OpenApi.Models.OpenApiInfo
            //    {
            //        Title = "Expert API",
            //        Version = "v1"
            //    });

            //    options.DocInclusionPredicate((docName, apiDesc) =>
            //    {
            //        var groupName = apiDesc.GroupName ?? string.Empty;
            //        return docName.ToLower() == groupName.ToLower();
            //    });
            //});
            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/account/swagger.json", "Accounts API v1");
                    options.SwaggerEndpoint("/swagger/services/swagger.json", "Services API v1");
                    options.SwaggerEndpoint("/swagger/expert/swagger.json", "Expert API v1");
                    options.SwaggerEndpoint("/swagger/cart/swagger.json", "Cart API v1");
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.MigrateContext<ApplicationDbContext>()
                .Run();
        }
    }
}
