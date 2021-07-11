using System;
using System.Collections.Generic;
using Xayah.Finances.Contracts.Common;
using Xayah.Finances.Domain.Accounts.Transactions;

namespace Xayah.Finances.Domain.Accounts
{
    public partial class Account : IAggregationRoot
    {
        public Guid Id { get; private set; }
        public string BankCode { get; private set; }
        public string Number { get; private set; }
        public IList<Transaction> Transactions { get; private set; }
    }
}