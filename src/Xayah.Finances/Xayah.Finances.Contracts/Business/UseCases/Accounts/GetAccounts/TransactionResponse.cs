using System;
using Xayah.Finances.Domain.Common.Enumerators;

namespace Xayah.Finances.Contracts.Business.UseCases.Accounts.GetAccounts
{
    public class TransactionResponse
    {
        public TransactionType Type { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public decimal Value { get; set; }
    }
}