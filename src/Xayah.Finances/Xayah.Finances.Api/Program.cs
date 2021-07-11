using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Diagnostics.CodeAnalysis;

namespace Xayah.Finances.Api
{
    public static class Program
    {
        [ExcludeFromCodeCoverage]
        public static void Main(string[] args) =>
            CreateWebHostBuilder(args).Build().Run();

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                   .UseIIS()
                   .UseStartup<Startup>();
    }
}
