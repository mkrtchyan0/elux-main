using Microsoft.OpenApi.Models;

namespace Elux.Api.Extensions
{
    public static class ExtensionForSwagger
    {
        public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("account", new OpenApiInfo
                {
                    Title = "Accounts API",
                    Version = "v1"
                });

                options.SwaggerDoc("services", new OpenApiInfo
                {
                    Title = "Services API",
                    Version = "v1"
                });

                options.SwaggerDoc("cart", new OpenApiInfo
                {
                    Title = "Cart API",
                    Version = "v1"
                });

                options.SwaggerDoc("expert", new OpenApiInfo
                {
                    Title = "Expert API",
                    Version = "v1"
                });

                // Include only the relevant docs for each API based on group name
                options.DocInclusionPredicate((docName, apiDesc) =>
                {
                    var groupName = apiDesc.GroupName ?? string.Empty;
                    return docName.ToLower() == groupName.ToLower();
                });
            });

            return services;
        }
    }
}
