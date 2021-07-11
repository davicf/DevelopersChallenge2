using System;
using Xayah.Finances.Domain.Common;
using Xayah.Finances.Domain.Common.Enumerators;
using Xayah.Finances.Domain.Common.Extension;

namespace Xayah.Finances.Domain.Accounts.Transactions
{
    public partial class Transaction
    {
        public static Transaction Create(string type, string description, DateTime date, decimal value)
        {
            return new()
            {
                Type = type.GetValueByDescription<TransactionType>(),
                Description = description,
                Date = date,
                Value = value
            };
        }

        public ValidationResultRules Validate() => TransactionBusinessRule.Create().ValidateRules(this);
    }
}