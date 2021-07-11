using FluentValidation;
using Xayah.Finances.Domain.Common;
using Xayah.Finances.Domain.Common.Extension;

namespace Xayah.Finances.Domain.Accounts
{
    internal class AccountBusinessRule : AbstractValidator<Account>
    {
        public AccountBusinessRule()
        {
            UseRuleCode();
            UseRuleNumber();
        }

        public ValidationResultRules ValidateRules(Account account) =>
            Validate(account).Verify();

        public static AccountBusinessRule Create() =>
            new();

        #region Rules
        private void UseRuleCode()
        {
            RuleFor(acc => acc.BankCode)
                .NotEmpty()
                    .WithMessage("BankCode is required");
        }

        private void UseRuleNumber()
        {
            RuleFor(acc => acc.Number)
                .NotEmpty()
                    .WithMessage("Account number is required");
        }
        #endregion
    }
}