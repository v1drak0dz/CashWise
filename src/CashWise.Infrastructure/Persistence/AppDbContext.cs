using CashWise.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CashWise.Infrastructure.Persistence
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Transaction> Transactions => Set<Transaction>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
