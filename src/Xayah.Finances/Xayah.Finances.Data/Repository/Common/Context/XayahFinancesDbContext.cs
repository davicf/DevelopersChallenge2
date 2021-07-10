using Microsoft.EntityFrameworkCore;
using Xayah.Finances.Domain.Transactions;
using Xayah.Finances.Domain.Users;

namespace Xayah.Finances.Data.Repository.Common.Context
{
    public class XayahFinancesDbContext : DbContext
    {
        public XayahFinancesDbContext(DbContextOptions<XayahFinancesDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}