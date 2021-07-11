using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Xayah.Finances.Domain.Accounts.Transactions;

namespace Xayah.Finances.Data.Repository.Accounts.Transactions
{
    public class TransactionMapping : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Type);
            builder.Property(p => p.Description);
            builder.Property(p => p.Date);
            builder.Property(p => p.Value);

            builder.HasOne(p => p.Account)
                   .WithMany(p => p.Transactions)
                   .HasForeignKey(p => p.AccountId)
                   .OnDelete(DeleteBehavior.Cascade)
                   .IsRequired();
        }
    }
}