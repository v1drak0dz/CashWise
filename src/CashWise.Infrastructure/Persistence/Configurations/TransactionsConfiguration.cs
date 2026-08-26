using CashWise.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CashWise.Infrastructure.Persistence.Configurations
{
    internal class TransactionsConfigurations : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Amount).HasPrecision(18, 2);
            builder.Property(x => x.Date).IsRequired();
            builder.Property(x => x.TransactionType).IsRequired();
            builder.Property(x => x.TransactionCategory).IsRequired();
        }
    }
}
