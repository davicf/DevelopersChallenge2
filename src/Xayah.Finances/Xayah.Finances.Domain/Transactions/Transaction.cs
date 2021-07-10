using System;
using Xayah.Finances.Contracts.Data.Repository.Common;
using Xayah.Finances.Domain.Common.Enumerators;

namespace Xayah.Finances.Domain.Transactions
{
    public class Transaction : IEntity
    {
        public Guid Id { get; private set; }
        public TransactionType Type { get; private set; }
        public string Description { get; private set; }
        public DateTime Date { get; private set; }
        public decimal Value { get; private set; }

        //public Guid UserId { get; private set; } Usar?
        //public User User { get; private set; } Usar?
    }
}