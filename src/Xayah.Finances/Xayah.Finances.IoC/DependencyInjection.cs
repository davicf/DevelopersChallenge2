using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Xayah.Finances.Business.UseCases.Accounts.AddAccounts;
using Xayah.Finances.Business.UseCases.Accounts.GetAccounts;
using Xayah.Finances.Contracts.Business.UseCases.Accounts.AddAccounts;
using Xayah.Finances.Contracts.Business.UseCases.Accounts.GetAccounts;
using Xayah.Finances.Contracts.Data.Repository;
using Xayah.Finances.Contracts.Data.Specification.Accounts;
using Xayah.Finances.Data.Repository.Accounts;
using Xayah.Finances.Data.Specification.Accounts;
using Xayah.Finances.Domain.Accounts;

namespace Xayah.Finances.IoC
{
    public static class DependencyInjection
    {
        public static void AddMyDependencies(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.Load("Xayah.Finances.Business"));

            #region UseCases
            services.AddScoped<IAddAccountsUseCase, AddAccountsUseCase>();
            services.AddScoped<IGetAccountsUseCase, GetAccountsUseCase>();
            #endregion

            #region Repositories
            services.AddScoped<IRepository<Account>, AccountRepository>();
            #endregion

            #region Specifications
            services.AddTransient<IGetAccountByNumberSpecification, GetAccountByNumberSpecification>();
            #endregion
        }
    }
}