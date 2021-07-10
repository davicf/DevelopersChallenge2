using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Linq;

namespace Xayah.Finances.Api.Configuration.Options
{
    public static class SwaggerGenOptionsFactory
    {
        public static Action<SwaggerGenOptions> Create()
        {
            var openApiInfo = new OpenApiInfo
            {
                Title = "API - Xayah Finances",
                Version = "v1",
                Description = "API - Xayah Finances",
            };

            return options =>
            {
                options.SwaggerDoc("v1", openApiInfo);
                options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                options.OrderActionsBy(d => d.GroupName);
                options.CustomSchemaIds(x => x.FullName);
            };
        }
    }
}
