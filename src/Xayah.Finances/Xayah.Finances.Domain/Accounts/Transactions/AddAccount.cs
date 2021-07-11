namespace Xayah.Finances.Domain.Accounts.Transactions
{
    public partial class Transaction
    {
        public void AddAccount(Account account)
        {
            Account = account;
            AccountId = account.Id;
        }
    }
}