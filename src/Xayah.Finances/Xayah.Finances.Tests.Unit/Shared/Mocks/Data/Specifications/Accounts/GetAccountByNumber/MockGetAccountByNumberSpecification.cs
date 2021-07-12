using FakeItEasy;
using Xayah.Finances.Contracts.Data.Specification.Accounts;
using Xayah.Finances.Data.Specification.Accounts;

namespace Xayah.Finances.Tests.Unit.Shared.Mocks.Data.Specifications.Accounts.GetAccountByNumber
{
    public class MockGetAccountByNumberSpecification : BaseMockBuilder<IGetAccountByNumberSpecification>
    {
        public GetAccountByNumberSpecificationQuery Returns { get; set; } = new GetAccountByNumberSpecificationQuery(default);

        internal override Fake<IGetAccountByNumberSpecification> BuildMock()
        {
            var mock = new Fake<IGetAccountByNumberSpecification>();

            mock.CallsTo(x => x.Execute(A.Dummy<string>()))
                .Returns(Returns);

            return mock;
        }
    }
}