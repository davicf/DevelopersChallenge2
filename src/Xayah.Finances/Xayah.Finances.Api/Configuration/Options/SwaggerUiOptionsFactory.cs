using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;

namespace Xayah.Finances.Api.Configuration.Options
{
    public static class SwaggerUiOptionsFactory
    {
        public static Action<SwaggerUIOptions> Create(IConfiguration config)
        {
            return options =>
            {
                options.SwaggerEndpoint(config["swagger:path"], "Xayah Finances - Api");
            };
        }
    }
}
