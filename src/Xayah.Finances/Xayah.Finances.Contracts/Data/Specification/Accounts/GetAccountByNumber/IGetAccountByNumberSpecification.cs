using Xayah.Finances.Domain.Accounts;

namespace Xayah.Finances.Contracts.Data.Specification.Accounts
{
    public interface IGetAccountByNumberSpecification
    {
        ISpecification<Account> Execute(string number);
    }
}