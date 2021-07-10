using Microsoft.AspNetCore.Cors.Infrastructure;
using System;

namespace Xayah.Finances.Api.Configuration.Options
{
    public static class CorsOptionsFactory
    {
        public static Action<CorsOptions> Create()
        {
            var corsPolicy = new CorsPolicyBuilder()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowAnyOrigin()
                .Build();

            return options => options.AddPolicy("CorsPolicy", corsPolicy);
        }
    }
}
