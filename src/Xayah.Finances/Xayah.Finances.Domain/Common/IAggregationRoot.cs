using System;

namespace Xayah.Finances.Domain.Common
{
    public interface IAggregationRoot : IEntity
    {
        Guid Id { get; }
    }
}