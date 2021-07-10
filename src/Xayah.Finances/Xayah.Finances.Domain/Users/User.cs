using System;
using System.Collections.Generic;
using Xayah.Finances.Contracts.Data.Repository.Common;
using Xayah.Finances.Domain.Transactions;

namespace Xayah.Finances.Domain.Users
{
    public class User : IAggregationRoot
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public IEnumerable<Transaction> Transactions { get; private set; }
    }
}