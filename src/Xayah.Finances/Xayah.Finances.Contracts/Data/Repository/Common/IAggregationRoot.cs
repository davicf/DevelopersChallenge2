using System;

namespace Xayah.Finances.Contracts.Data.Repository.Common
{
    public interface IAggregationRoot : IEntity
    {
        Guid Id { get; }
    }
}