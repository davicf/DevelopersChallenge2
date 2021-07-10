using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xayah.Finances.Api.Configuration.Extensions;

namespace Xayah.Finances.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMyCors();
            services.AddMyRequestLocalizationOptions();
            services.AddControllers();
            services.AddMySwaggerGen();
            //services.AddMyDependencies(Configuration);
            services.AddMyDbContext(Configuration);
            services.AddMyResponseCompression();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMyExceptionHandler(env);
            app.UseCors("CorsPolicy");
            app.UseHsts();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseMySwagger(Configuration);
            //app.UseAuthorization();
            app.UseRequestLocalization();
            app.UseMyEndpoints();
            app.UseResponseCompression();
        }
    }
}
