using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xayah.Finances.Api.Configuration.Options;
using Xayah.Finances.Data.Repository.Common.Context;

namespace Xayah.Finances.Api.Configuration.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMyCors(this IServiceCollection services) =>
            services.AddCors(CorsOptionsFactory.Create());

        public static IServiceCollection AddMyResponseCompression(this IServiceCollection services) =>
            services.AddResponseCompression(CorsOptionsCompressionFactory.Create());

        public static IServiceCollection AddMyRequestLocalizationOptions(this IServiceCollection services) =>
            services.Configure(RequestLocalizationOptionsFactory.Create());

        public static IServiceCollection AddMySwaggerGen(this IServiceCollection services) =>
            services.AddSwaggerGen(SwaggerGenOptionsFactory.Create());

        public static IServiceCollection AddMyDbContext(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<XayahFinancesDbContext>(
               options =>
                   options.UseSqlServer(config.GetConnectionString("ConnectionString"), x => x.MigrationsAssembly("Xayah.Finances.Data")));

            return services;
        }
    }
}
