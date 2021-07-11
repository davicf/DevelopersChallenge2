using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xayah.Finances.Contracts.Common;
using Xayah.Finances.Contracts.Data.Specification;

namespace Xayah.Finances.Contracts.Data.Repository
{
    public interface IRepository<T> where T : IAggregationRoot
    {
        Task<T> GetAsync(ISpecification<T> specification, bool useTracking = true);
        Task<IEnumerable<T>> GetListAsync(ISpecification<T> specification, bool useTracking = true);
        Task AddAsync(T entity);
    }
}