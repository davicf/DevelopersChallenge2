using Xayah.Finances.Domain.Accounts;

namespace Xayah.Finances.Data.Specification.Accounts
{
    public class GetAccountByNumberSpecificationQuery : Specification<Account>
    {
        public GetAccountByNumberSpecificationQuery(string number) : base(acc => acc.Number == number)
        {
            AddInclusion(acc => acc.Transactions);
        }
    }
}