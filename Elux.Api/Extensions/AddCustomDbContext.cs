using Elux.Dal.Data;
using Microsoft.EntityFrameworkCore;

namespace Elux.Api.Extensions
{
    public static class AddCustomDbContext
    {
        public static IServiceCollection MyAddDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(connectionString));

            return services;
        }
    }
}