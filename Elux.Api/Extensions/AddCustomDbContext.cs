using Elux.Dal.Data;
using Microsoft.EntityFrameworkCore;

namespace Elux.Api.Extensions
{
    public static class CustomDbContextExtension
    {
        public static IServiceCollection AddCustomDbContext(this IHostApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("Postgres");

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(connectionString));

            return builder.Services;
        }
        public static IServiceCollection AddCustomDbContextByServices(this IServiceCollection services, IConfiguration Configuration)
        {
            var connectionString = Configuration.GetConnectionString("Postgres");

            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(connectionString));

            return services;
        }
    }
}