using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xayah.Finances.Contracts.Business.Accounts;

namespace Xayah.Finances.Business.Services
{
    public partial class AccountService : IAccountService
    {
        public async Task AddTransactionsAsync(IEnumerable<IFormFile> files)
        {
            var accounts = await CreateAccounts(files);
            ValidateAccounts(accounts);
        }
    }
}