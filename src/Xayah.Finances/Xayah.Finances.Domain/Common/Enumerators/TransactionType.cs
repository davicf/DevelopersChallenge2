using System.ComponentModel;

namespace Xayah.Finances.Domain.Common.Enumerators
{
    public enum TransactionType
    {
        [Description("Debit")]
        Debit = 1,
        [Description("Credit")]
        Credit = 2
    }
}