using Xayah.Finances.Contracts.Data.Specification;
using Xayah.Finances.Contracts.Data.Specification.Accounts;
using Xayah.Finances.Domain.Accounts;

namespace Xayah.Finances.Data.Specification.Accounts
{
    public class GetAccountByNumberSpecification : IGetAccountByNumberSpecification
    {
        public ISpecification<Account> Execute(string number) =>
            new GetAccountByNumberSpecificationQuery(number);
    }
}