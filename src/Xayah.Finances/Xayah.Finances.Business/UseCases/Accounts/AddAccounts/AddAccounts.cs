using System.Collections.Generic;
using System.Threading.Tasks;
using System.Transactions;
using Xayah.Finances.Domain.Accounts;
using Xayah.Finances.Domain.Common.Exception;
using Xayah.Finances.Domain.Common.Extension;

namespace Xayah.Finances.Business.UseCases.Accounts.AddAccounts
{
    public partial class AddAccountsUseCase
    {
        private async Task AddAccounts(List<Account> accounts)
        {
            using var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

            foreach (var account in accounts)
            {
                var accountVerify = await _accountRepository.GetAsync(_getAccountByNumberSpecification.Execute(account.Number));

                if (!accountVerify.IsNull())
                    throw new BusinessRuleException($"Account {accountVerify.Number} already exists");

                await _accountRepository.AddAsync(account);
            }

            transactionScope.Complete();
        }
    }
}