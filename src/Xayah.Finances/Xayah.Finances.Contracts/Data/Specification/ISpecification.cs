using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Xayah.Finances.Contracts.Data.Repository.Common;

namespace Xayah.Finances.Contracts.Data.Specification
{
    public interface ISpecification<T> : IEntity
    {
        Expression<Func<T, bool>> Criterion { get; }
        List<Expression<Func<T, object>>> Inclusions { get; }
        IList<string> SubInclusions { get; }
        List<Expression<Func<T, object>>> InclusionsFilter { get; }
    }
}