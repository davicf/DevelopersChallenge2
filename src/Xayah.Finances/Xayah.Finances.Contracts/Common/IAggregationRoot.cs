using System;

namespace Xayah.Finances.Contracts.Common
{
    public interface IAggregationRoot : IEntity
    {
        Guid Id { get; }
    }
}