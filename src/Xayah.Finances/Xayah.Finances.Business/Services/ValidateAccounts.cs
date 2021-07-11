using System.Collections.Generic;
using Xayah.Finances.Domain.Accounts;
using Xayah.Finances.Domain.Common.Exception;

namespace Xayah.Finances.Business.Services
{
    public partial class AccountService
    {
        private void ValidateAccounts(List<Account> accounts)
        {
            foreach (var account in accounts)
            {
                var validationAccount = account.Validate();

                if (!validationAccount.IsValid)
                    throw new BusinessRuleException(validationAccount.Errors);

                foreach (var transaction in account.Transactions)
                {
                    var validationTransaction = transaction.Validate();

                    if (!validationTransaction.IsValid)
                        throw new BusinessRuleException(validationTransaction.Errors);
                }
            }
        }
    }
}