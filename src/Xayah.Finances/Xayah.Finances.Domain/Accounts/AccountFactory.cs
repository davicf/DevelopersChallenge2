using Xayah.Finances.Domain.Common;

namespace Xayah.Finances.Domain.Accounts
{
    public partial class Account
    {
        public static Account Create(string bankCode, string number) =>
            new()
            {
                BankCode = bankCode,
                Number = number
            };

        public ValidationResultRules Validate() => AccountBusinessRule.Create().ValidateRules(this);
    }
}