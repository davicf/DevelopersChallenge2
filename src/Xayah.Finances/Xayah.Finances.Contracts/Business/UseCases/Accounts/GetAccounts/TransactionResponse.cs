using System;

namespace Xayah.Finances.Contracts.Business.UseCases.Accounts.GetAccounts
{
    public class TransactionResponse
    {
        public string Type { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public decimal Value { get; set; }
    }
}