using Microsoft.EntityFrameworkCore;
using Xayah.Finances.Data.Repository.Accounts;
using Xayah.Finances.Data.Repository.Accounts.Transactions;
using Xayah.Finances.Domain.Accounts;
using Xayah.Finances.Domain.Accounts.Transactions;

namespace Xayah.Finances.Data.Repository.Common.Context
{
    public class XayahFinancesDbContext : DbContext
    {
        public XayahFinancesDbContext(DbContextOptions<XayahFinancesDbContext> options) : base(options) { }

        public DbSet<Account> Account { get; set; }
        public DbSet<Transaction> Transaction { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountMapping());
            modelBuilder.ApplyConfiguration(new TransactionMapping());
        }
    }
}