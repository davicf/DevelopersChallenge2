using System.Collections.Generic;
using System.Linq;
using Xayah.Finances.Domain.Accounts;

namespace Xayah.Finances.Business.Services
{
    public partial class AccountService
    {
        private void AddAccountNoDuplicity(List<Account> accounts, Account account)
        {
            if (accounts.Any(acc => acc.BankCode == account.BankCode && acc.Number == account.Number))
            {
                var accountDuplicaty = accounts.First(acc => acc.BankCode == account.BankCode && acc.Number == account.Number);

                AddTransactionsNoDuplicity(account, accountDuplicaty);

                return;
            }

            accounts.Add(account);
        }

        private void AddTransactionsNoDuplicity(Account account, Account accountDuplicaty)
        {
            foreach (var transaction in account.Transactions)
            {
                if (!accountDuplicaty.Transactions.Any(t => t.Date == transaction.Date &&
                                                      t.Description == transaction.Description &&
                                                      t.Type == transaction.Type &&
                                                      t.Value == transaction.Value))
                {
                    accountDuplicaty.Transactions.Add(transaction);
                }
            }
        }
    }
}