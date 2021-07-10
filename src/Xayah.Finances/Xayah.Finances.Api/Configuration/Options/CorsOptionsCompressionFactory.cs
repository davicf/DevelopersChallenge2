using Microsoft.AspNetCore.ResponseCompression;
using System;
using System.Linq;

namespace Xayah.Finances.Api.Configuration.Options
{
    public static class CorsOptionsCompressionFactory
    {
        public static Action<ResponseCompressionOptions> Create()
        {
            return options =>
            {
                options.Providers.Add<GzipCompressionProvider>();
                options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "application/json" });
            };
        }
    }
}
