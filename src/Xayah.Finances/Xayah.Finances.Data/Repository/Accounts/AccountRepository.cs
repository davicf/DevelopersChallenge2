using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xayah.Finances.Contracts.Data.Repository;
using Xayah.Finances.Contracts.Data.Specification;
using Xayah.Finances.Data.Repository.Common.Context;
using Xayah.Finances.Domain.Accounts;

namespace Xayah.Finances.Data.Repository.Accounts
{
    public class AccountRepository : IRepository<Account>
    {
        private readonly XayahFinancesDbContext _context;

        public AccountRepository(XayahFinancesDbContext context) => _context = context;

        public async Task AddAsync(Account entity)
        {
            _context.Account.Add(entity);

            await _context.SaveChangesAsync();
        }

        public async Task<Account> GetAsync(ISpecification<Account> specification, bool useTracking = true)
        {
            IQueryable<Account> query = _context.Account;

            foreach (var inclusion in specification.Inclusions)
            {
                query.Include(inclusion);
            }

            foreach (var subInclusion in specification.SubInclusions)
            {
                query = query.Include(subInclusion);
            }

            return await (useTracking ? query.FirstOrDefaultAsync(specification.Criterion) : query.AsNoTracking().FirstOrDefaultAsync(specification.Criterion));
        }

        public async Task<IEnumerable<Account>> GetListAsync(ISpecification<Account> specification, bool useTracking = true)
        {
            IQueryable<Account> query = _context.Account;

            foreach (var inclusion in specification.Inclusions)
            {
                query = query.Include(inclusion);
            }

            foreach (var subInclusion in specification.SubInclusions)
            {
                query = query.Include(subInclusion);
            }

            return await (useTracking ? query.Where(specification.Criterion).ToListAsync() : query.AsNoTracking().Where(specification.Criterion).ToListAsync());
        }
    }
}