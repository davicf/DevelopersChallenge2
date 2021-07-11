using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Xayah.Finances.Domain.Accounts;

namespace Xayah.Finances.Data.Repository.Accounts
{
    public class AccountMapping : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.BankCode).IsRequired();
            builder.Property(p => p.Number).IsRequired();
        }
    }
}