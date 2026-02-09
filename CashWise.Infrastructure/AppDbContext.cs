using CashWise.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CashWise.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<Account> Accounts => Set<Account>();
        public DbSet<Transaction> Transactions => Set<Transaction>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder b)
        {
            #region [Accounts Table]
            
            b.Entity<Account>().HasKey(x => x.Id);
            b.Entity<Account>().Property(x => x.BankName).IsRequired().HasMaxLength(200);

            #endregion [Accounts Table]

            #region [Accounts Table]

            b.Entity<Transaction>().HasKey(x => x.Id);
            b.Entity<Transaction>().Property(x => x.Description).IsRequired();
            b.Entity<Transaction>().Property(x => x.Amount).IsRequired();
            b.Entity<Transaction>().Property(x => x.Category).IsRequired();
            b.Entity<Transaction>().Property(x => x.TransactionType).IsRequired();

            #endregion [Accounts Table]
        }
    }
}