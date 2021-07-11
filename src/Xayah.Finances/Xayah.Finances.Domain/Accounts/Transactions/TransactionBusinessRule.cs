using FluentValidation;
using System;
using Xayah.Finances.Domain.Common;
using Xayah.Finances.Domain.Common.Extension;

namespace Xayah.Finances.Domain.Accounts.Transactions
{
    internal class TransactionBusinessRule : AbstractValidator<Transaction>
    {
        public TransactionBusinessRule()
        {
            UseRuleType();
            UseRuleDescription();
            UseRuleDate();
            UseRuleValue();
        }

        public ValidationResultRules ValidateRules(Transaction transaction) =>
            Validate(transaction).Verify();

        public static TransactionBusinessRule Create() =>
            new();

        #region Rules
        private void UseRuleType()
        {
            RuleFor(t => t.Type)
                .NotEmpty()
                    .WithMessage("Type is required")
                .Must(Enum.IsDefined)
                    .WithMessage("Type invalid");
        }

        private void UseRuleDescription()
        {
            RuleFor(t => t.Description)
                .NotEmpty()
                    .WithMessage("Description is required");
        }

        private void UseRuleDate()
        {
            RuleFor(t => t.Date)
                .NotEmpty()
                    .WithMessage("Date is required");
        }

        private void UseRuleValue()
        {
            RuleFor(t => t.Value)
                .NotEmpty()
                    .WithMessage("Value is required");
        }
        #endregion
    }
}