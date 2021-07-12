using System.Collections.Generic;
using System.Threading.Tasks;
using Xayah.Finances.Contracts.Data.Specification;
using Xayah.Finances.Domain.Common;

namespace Xayah.Finances.Contracts.Data.Repository
{
    public interface IRepository<T> where T : IAggregationRoot
    {
        Task<T> GetAsync(ISpecification<T> specification, bool useTracking = true);
        Task<IEnumerable<T>> ListAsync(ISpecification<T> specification, bool useTracking = true);
        Task<IEnumerable<T>> ListAsync(bool useTracking = true);
        Task AddAsync(T entity);
    }
}