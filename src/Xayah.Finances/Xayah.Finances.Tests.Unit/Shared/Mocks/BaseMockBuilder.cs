using FakeItEasy;

namespace Xayah.Finances.Tests.Unit.Shared.Mocks
{
    public abstract class BaseMockBuilder<T> where T : class
    {
        private Fake<T> InstanceMock { get; set; }

        public Fake<T> Mock
        {
            get
            {
                if (InstanceMock == null)
                {
                    InstanceMock = BuildMock();
                }
                return InstanceMock;
            }
        }

        public T Instance
        {
            get
            {
                return Mock.FakedObject;
            }
        }

        internal abstract Fake<T> BuildMock();
    }
}