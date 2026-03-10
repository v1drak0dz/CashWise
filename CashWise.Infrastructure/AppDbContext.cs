using CashWise.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CashWise.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<Account> Accounts => Set<Account>();
        public DbSet<Transaction> Transactions => Set<Transaction>();
        public DbSet<InvestmentPosition> InvestmentPositions => Set<InvestmentPosition>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder b)
        {
            #region [Accounts Table]
            
            b.Entity<Account>().HasKey(x => x.Id);
            b.Entity<Account>().Property(x => x.BankName).IsRequired().HasMaxLength(200);

            #endregion [Accounts Table]

            #region [Transactions Table]

            b.Entity<Transaction>().HasKey(x => x.Id);
            b.Entity<Transaction>().Property(x => x.Description).IsRequired();
            b.Entity<Transaction>().Property(x => x.Amount).IsRequired();
            b.Entity<Transaction>().Property(x => x.TransactionCategory).IsRequired();
            b.Entity<Transaction>().Property(x => x.TransactionType).IsRequired();

            #endregion [Transactions Table]

            #region [InvestmentPositions Table]

            b.Entity<InvestmentPosition>().HasKey(x => x.Id);
            b.Entity<InvestmentPosition>().Property(x => x.Asset).IsRequired();
            b.Entity<InvestmentPosition>().Property(x => x.Quantity).IsRequired();
            b.Entity<InvestmentPosition>().Property(x => x.AveragePrice).IsRequired();

            #endregion
        }
    }
}