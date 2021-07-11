using Microsoft.Extensions.DependencyInjection;
using Xayah.Finances.Business.Services;
using Xayah.Finances.Contracts.Business.Accounts;

namespace Xayah.Finances.IoC
{
    public static class DependencyInjection
    {
        public static void AddMyDependencies(this IServiceCollection services)
        {
            #region Services
            services.AddScoped<IAccountService, AccountService>();
            //services.Scan(scan => scan.FromApplicationDependencies()
            //                          .AddClasses(c => c.Where(x => x.Name.EndsWith("Service")))
            //                          .AsImplementedInterfaces()
            //                          .WithScopedLifetime());
            #endregion
        }
    }
}