using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xayah.Finances.Business.Common.Extensions;
using Xayah.Finances.Domain.Accounts;

namespace Xayah.Finances.Business.Services
{
    public partial class AccountService
    {
        private async Task<List<Account>> CreateAccounts(IEnumerable<IFormFile> files)
        {
            var accounts = new List<Account>();

            foreach (var file in files)
            {
                using var reader = new StreamReader(file.OpenReadStream());

                while (!reader.EndOfStream)
                {
                    var line = await reader.ReadLineAsync();

                    if (line.StartsWith("<BANKACCTFROM>"))
                    {
                        var account = await CreateAccount(reader);
                        var transactions = await CreateTransactions(reader);

                        account.AddTransactions(transactions);

                        AddAccountNoDuplicity(accounts, account);
                    }
                }
            }

            return accounts;
        }

        private async Task<Account> CreateAccount(StreamReader reader)
        {
            var bankCode = await reader.ReadLineAsync();
            var numberCode = await reader.ReadLineAsync();

            var account = Account.Create(bankCode.GetValueLine(), numberCode.GetValueLine());

            return account;
        }
    }
}