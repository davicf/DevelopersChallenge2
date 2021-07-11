using System.Collections.Generic;
using Xayah.Finances.Domain.Accounts.Transactions;
using Xayah.Finances.Domain.Common.Extension;

namespace Xayah.Finances.Domain.Accounts
{
    public partial class Account
    {
        public void AddTransactions(IList<Transaction> transactions)
        {
            if (Transactions.IsNull())
                Transactions = new List<Transaction>();

            foreach (var transaction in transactions)
            {
                Transactions.Add(transaction);
                transaction.AddAccount(this);
            }
        }
    }
}