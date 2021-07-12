using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xayah.Finances.Contracts.Business.UseCases.Accounts.AddAccounts;
using Xayah.Finances.Contracts.Data.Repository;
using Xayah.Finances.Contracts.Data.Specification.Accounts;
using Xayah.Finances.Domain.Accounts;

namespace Xayah.Finances.Business.UseCases.Accounts.AddAccounts
{
    public partial class AddAccountsUseCase : IAddAccountsUseCase
    {
        private readonly IGetAccountByNumberSpecification _getAccountByNumberSpecification;
        private readonly IRepository<Account> _accountRepository;

        public AddAccountsUseCase(IRepository<Account> accountRepository,
                              IGetAccountByNumberSpecification getAccountByNumberSpecification)
        {
            _getAccountByNumberSpecification = getAccountByNumberSpecification;
            _accountRepository = accountRepository;
        }

        public async Task<IList<AddAccountResponse>> AddAccountsAsync(IList<IFormFile> files)
        {
            ValidateFiles(files);
            var accounts = await CreateAccounts(files);
            ValidateAccounts(accounts);
            await AddAccounts(accounts);

            return ResponseReturn(accounts);
        }

        private void ValidateFiles(IEnumerable<IFormFile> files)
        {

        }
    }
}