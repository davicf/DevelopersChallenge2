using System;
using Xayah.Finances.Domain.Common;
using Xayah.Finances.Domain.Common.Enumerators;

namespace Xayah.Finances.Domain.Accounts.Transactions
{
    public partial class Transaction : IEntity
    {
        public Guid Id { get; private set; }
        public TransactionType Type { get; private set; }
        public string Description { get; private set; }
        public DateTime Date { get; private set; }
        public decimal Value { get; private set; }

        public Guid AccountId { get; private set; }
        public Account Account { get; private set; }
    }
}