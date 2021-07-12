using System.Collections.Generic;

namespace Xayah.Finances.Contracts.Business.UseCases.Accounts.GetAccounts
{
    public class GetAccountResponse
    {
        public string BankCode { get; set; }
        public string Number { get; set; }
        public IList<TransactionResponse> Transactions { get; set; }
    }
}