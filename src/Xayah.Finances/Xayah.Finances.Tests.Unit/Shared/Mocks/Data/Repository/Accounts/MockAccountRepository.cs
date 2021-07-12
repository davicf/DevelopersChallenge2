using FakeItEasy;
using System.Collections.Generic;
using Xayah.Finances.Contracts.Data.Repository;
using Xayah.Finances.Contracts.Data.Specification;
using Xayah.Finances.Domain.Accounts;

namespace Xayah.Finances.Tests.Unit.Shared.Mocks.Data.Repository.Accounts
{
    public class MockAccountRepository : BaseMockBuilder<IRepository<Account>>
    {
        private readonly Fake<IRepository<Account>> _mock = new Fake<IRepository<Account>>();

        internal override Fake<IRepository<Account>> BuildMock() => _mock;

        public MockAccountRepository Get(Account account)
        {
            _mock.CallsTo(x => x.GetAsync(A.Dummy<ISpecification<Account>>(), A.Dummy<bool>()))
                .WithAnyArguments()
                .Returns(account);

            return this;
        }

        public MockAccountRepository ToList(IEnumerable<Account> accounts)
        {
            _mock.CallsTo(x => x.ListAsync(A.Dummy<ISpecification<Account>>(), A.Dummy<bool>()))
                .WithAnyArguments()
                .Returns(accounts);

            return this;
        }
    }
}